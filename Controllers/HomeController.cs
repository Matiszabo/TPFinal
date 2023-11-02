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

    public IActionResult VerificarUsuario(Usuario usuario)
    {
        if (VerificarSiExisteUsuario(usuario) == true)
        {
            Usuario usuario = BD.BuscarUsuarioXNombre(usuario.nombre);
            if (usuario.contraseña == usuario.contraseña)
            {
                return RedirectToAction("PaginaPrincipal", "Home");
            }
            else
            {
                ViewBag.Mensaje = "La contraseña es incorrecta";
                return View("IniciarSesion");
            }
        }
        else
        {
            ViewBag.Mensaje = "El usuario no existe o es incorrecto";
            return View("IniciarSesion");
        }
    }
    public bool VerificarSiExisteUsuario(Usuario usuario)
    {
        return BD.BuscarUsuarioXNombre(usuario.nombre) != null;
    }
    public IActionResult VerificarUsuarioRegistro(Usuario usuario, string Contraseña2)
    {
        if(VerificarSiExisteUsuario(usuario) == true)
        {
            ViewBag.Mensaje = "El usuario ya existe, ingrese otro nombre";
            return View("Registrarse");
        }
        if(usuario.contraseña != Contraseña2)
        {
            ViewBag.Mensaje = "Las contraseñas no coinciden";
            return View("Registrarse");
        }
        BD.AgregarUsuario(usuario);

        return RedirectToAction("PaginaPrincipal", "Home");
    }
    public IActionResult Registrarse()
    {
        return View();
    }
    public IActionResult OlvidoContraseña(Usuario usuario)
    {
        ViewBag.Usuario = BD.BuscarContraXUsuario(usuario.Nombre);
        ViewBag.Mensaje = "La contraseña es: " + ViewBag.Usuario.Contraseña;
        return View();
    }
    public IActionResult BuscarOlvidoContraseña()
    {
        return View("OlvidoContraseña");
    }

    [HttpPost]
    public IActionResult InsertarUsuario(Usuario usuario, string Contraseña2)
    {
        if (usuario.contraseña == Contraseña2)
        {
            BD.AgregarUsuario(usuario);
            return RedirectToAction("PaginaPrincipal", "Home");
        }
        else
        {
            ViewBag.Mensaje = "Las contraseñas no coinciden";
            return View("Registrarse");
        }
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
