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

     public IActionResult VerificarContraseña(string nombre, string contraseña)
    {
        if (string.IsNullOrEmpty(contraseña)  || string.IsNullOrEmpty(nombre) )
        {
            ViewBag.Error = "Se deben completar todos los campos";
            return RedirectToAction("Index");
        }
        else
        {
            Usuario comparar = BD.LoginIngresado(nombre, contraseña);
        
            if (comparar != null)
            {
                if (contraseña == comparar.contraseña)
                {
                    return RedirectToAction("PaginaPrincipal", "Home", new {ID_Usuario=comparar.ID_Usuario});
                }
            }
            else
            {
                ViewBag.Verificar = "El usuario y/o contraseña ingresada son incorrectos";
            }
            return View("Index");
        }
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
