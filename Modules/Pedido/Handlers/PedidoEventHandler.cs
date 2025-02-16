using System;
using System.Threading.Tasks;
using Core.Messages.IntegrationEvents;
using Rebus.Handlers;

namespace Pedido;
public class PedidoEventHandler : IHandleMessages<PedidoIniciadoEvent>
{
    public Task Handle(PedidoIniciadoEvent message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("PEGUEI EM OUTRO LUGAR");
        Console.ForegroundColor = ConsoleColor.Black;
        return Task.CompletedTask;
    }
}