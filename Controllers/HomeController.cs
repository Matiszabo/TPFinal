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

    public IActionResult IniciarSesion()
    {
        return View("IniciarSesion");
    }
    
    public IActionResult VerificarContraseña(string Usuario, string Contraseña)
    {
        if (string.IsNullOrEmpty(Contraseña)  || string.IsNullOrEmpty(Usuario) )
        {
            ViewBag.Error = "Se deben completar todos los campos";
            return RedirectToAction("Index");
        }
        else
        {
            Usuario comparar = BD.LoginIngresado(Usuario, Contraseña);
        
            Console.WriteLine("COntra ingresada: ", Contraseña);
            if (comparar != null)
            {
                if (Contraseña == comparar.contraseña)
                {
                    return RedirectToAction("PaginaPrincipal", "Home", new {ID_Usuario=comparar.ID_Usuario});
                }
            }
            else
            {
                ViewBag.Verificar = "El usuario y/o contraseña ingresada son incorrectos";  
            }
            return View("IniciarSesion");
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
    
    public IActionResult InsertarUsuario(Usuario nuevoUser, string Contraseña2)
    {
        if (nuevoUser.contraseña!= Contraseña2 || string.IsNullOrEmpty(nuevoUser.usuario) ||  string.IsNullOrEmpty(nuevoUser.contraseña) || string.IsNullOrEmpty(nuevoUser.nombre) || string.IsNullOrEmpty(nuevoUser.email) )
        {
            string alerta="No se compltaron todos los datos o las contraseñas ingresadas no coinciden";
            return RedirectToAction("Registrarse" , "Home", new {error=alerta});
        }
        else
        {
            BD.InsertUsuario(nuevoUser);
            return RedirectToAction("Index");
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
