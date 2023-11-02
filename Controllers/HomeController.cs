using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPFinal.Models;
using Prac.Models;

namespace TPFinal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("IniciarSesion");
    }

    public bool VerificarSiExisteUsuario(Usuario U)
    {
        return BD.BuscarUsuarioXNombre(U.nombre) != null;
    }
    public IActionResult VerificarUsuarioRegistro(Usuario U, string Contraseña2)
    {
        if(VerificarSiExisteUsuario(U) == true)
        {
            ViewBag.Mensaje = "El U ya existe, ingrese otro nombre";
            return View("Registrarse");
        }
        if(U.contraseña != Contraseña2)
        {
            ViewBag.Mensaje = "Las contraseñas no coinciden";
            return View("Registrarse");
        }
        BD.InsertUsuario(U);

        return RedirectToAction("PaginaPrincipal", "Home");
    }
    public IActionResult Registrarse()
    {
        return View();
    }
    public IActionResult OlvidoContraseña(Usuario U)
    {
        ViewBag.Usuario = BD.BuscarContraXUsuario(U.nombre);
        ViewBag.Mensaje = "La contraseña es: " + ViewBag.Usuario.Contraseña;
        return View();
    }
    public IActionResult BuscarOlvidoContraseña()
    {
        return View("OlvidoContraseña");
    }

    [HttpPost]
    public IActionResult InsertarUsuario(Usuario U, string Contraseña2, Viajes V)
    {
        if (U.contraseña == Contraseña2)
        {
            BD.InsertViaje(V);
            return RedirectToAction("PaginaPrincipal", "Home");
        }
        else
        {
            ViewBag.Mensaje = "Las contraseñas no coinciden";
            return View("Registrarse");
        }
    }

    public IActionResult Creditos()
    {
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
