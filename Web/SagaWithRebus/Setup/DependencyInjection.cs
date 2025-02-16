using Core.Messages;
using Pagamento;
using Pagamento.Commands;
using Pedido;
using Pedido.Commands;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;
using Rebus.Transport.InMem;

namespace SagaWithRebus.Setup;

public static class DependencyInjection
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        // Configure and register Rebus

        var nomeFila = "fila_rebus";

        services.AddRebus(configure => configure
            .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), nomeFila))
            // .Transport(t => t.UseRabbitMq("amqp://localhost", nomeFila))
            .Subscriptions(s => s.StoreInMemory())
            .Routing(r =>
            {
                r.TypeBased()
                    .MapAssemblyOf<Message>(nomeFila)
                    .MapAssemblyOf<IniciarPedidoCommand>(nomeFila)
                    .MapAssemblyOf<RealizarPagamentoCommand>(nomeFila);
            })
            .Sagas(s => s.StoreInMemory())
            .Options(o =>
            {
                o.SetNumberOfWorkers(1);
                o.SetMaxParallelism(1);
                o.SetBusName("Demo Rebus");
            })
        );

        // Register handlers 
        services.AutoRegisterHandlersFromAssemblyOf<PagamentoCommandHandler>();
        services.AutoRegisterHandlersFromAssemblyOf<PedidoSaga>();

        // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }
}