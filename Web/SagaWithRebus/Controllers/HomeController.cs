using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pedido.Commands;
using Rebus.Bus;
using SagaWithRebus.Models;

namespace SagaWithRebus.Controllers;
public class HomeController : Controller
{
    private readonly IBus _bus;

    public HomeController(IBus bus)
    {
        _bus = bus;
    }

    public IActionResult Index()
    {
        _bus.Send(new IniciarPedidoCommand { AggregateRoot = Guid.NewGuid()}).Wait();

        return View();
    }   

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}