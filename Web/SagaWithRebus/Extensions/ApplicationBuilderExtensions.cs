using Core.Messages.IntegrationEvents;

namespace SagaWithRebus.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ConfigureRebus(this IApplicationBuilder app)
    {
        app.UseRebus(c =>
        {
            c.Subscribe<PedidoIniciadoEvent>().Wait();
            c.Subscribe<PagamentoRealizadoEvent>().Wait();
            c.Subscribe<PedidoFinalizadoEvent>().Wait();
            c.Subscribe<PagamentoRecusadoEvent>().Wait();
            c.Subscribe<PedidoCanceladoEvent>().Wait();
        });
    }
}