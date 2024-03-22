using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace TPFinal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IWebHostEnvironment Environment;

    public HomeController(IWebHostEnvironment environment)
    {
        Environment = environment;
    }

    public IActionResult Index()
    {
        return View("IniciarSesion");
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult VerificarTarjeta(Tarjeta T)
    {
        Tarjeta tarjeta = BD.VerificarSiExisteTarjeta(T.Numero);
        if (tarjeta != null)
        {
            return RedirectToAction("Compra", "Home");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    public IActionResult Compra()
    {
        return View();
    }
    public IActionResult VerificarUsuario(Usuario U)
    {

        if (VerificarSiExisteUsuario(U) == true)
        {
            Usuario usuarioBD = BD.BuscarUsuarioXNombre(U.Nombre);
            if (usuarioBD.Contraseña == U.Contraseña)
            {
            return RedirectToAction("PaginaPrincipal", "Home", new { IdUsuario = usuarioBD.IdUsuario});
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
    public bool VerificarSiExisteUsuario(Usuario U)
    {
        return BD.BuscarUsuarioXNombre(U.Nombre) != null;
    }
    public IActionResult VerificarUsuarioRegistro(Usuario U, string Contraseña2)
    {

        if(VerificarSiExisteUsuario(U) == true)
        {
            ViewBag.Mensaje = "El usuario ya existe, ingrese otro nombre";
            return View("Registrarse");
        }
        if(U.Contraseña != Contraseña2)
        {
            ViewBag.Mensaje = "Las contraseñas no coinciden";
            return View("Registrarse");
        }
        BD.AgregarUsuarioSP(U);

        return RedirectToAction("PaginaPrincipal", "Home");
    }
    public IActionResult Registrarse()
    {
        return View();
    }
    public IActionResult OlvidoContraseña(Usuario U)
    {
        ViewBag.Usuario = BD.BuscarContraXUsuario(U.Nombre);
        if (ViewBag.Usuario != null) {
        ViewBag.Mensaje = "La contraseña es: " + ViewBag.Usuario.Contraseña;
        }
        else
        {
            ViewBag.Mensaje = "No encontramos el usuario ingresado";
        }
        return View();
    }
        public IActionResult BuscarOlvidoContraseña()
    {
        return View("OlvidoContraseña");
    }
    [HttpPost]
    public IActionResult InsertarUsuario(Usuario U, string Contraseña2)
    {
        if (U.Contraseña == Contraseña2)
        {
            BD.AgregarUsuarioSP(U);
            return RedirectToAction("PaginaPrincipal", "Home");
        }
        else
        {
            ViewBag.Mensaje = "Las contraseñas no coinciden";
            return View("Registrarse");
        }
    }
    
    public IActionResult PaginaPrincipal()
    {

        ViewBag.listaJuegos = BD.TraerJuegos();
        return View("Index");
    }
    public IActionResult ComprarJuego()
    {
        return View();
    }
    public Juego MostrarJuegosAjax(int IdJuego)
    {
        return BD.verInfoJuego(IdJuego);
    }

    public IActionResult AgregarJuego(int IdJuego)
    {
        ViewBag.listaCategorias = BD.TraerCategorias();
        ViewBag.Juego = IdJuego;
        return View();
    }
    public IActionResult GuardarJuego(Juego Jue, IFormFile Imagen)
    {
        if (Imagen.Length > 0)
        {
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + Imagen.FileName;
            using (var stream = System.IO.File.Create(wwwRootLocal))
            {
                Imagen.CopyTo(stream);
            }
            Jue.Imagen = Imagen.FileName;
        }
        BD.AgregarJuegoSP(Jue);
        ViewBag.detalleJuegos = BD.verInfoJuego(Jue.IdJuego);
        ViewBag.listaJuegos = BD.TraerJuegos();
        return RedirectToAction("PaginaPrincipal", "Home");
    }

    public Juego MostrarMasInfoAjax(int IdJuego)
    {
        return BD.verInfoJuego(IdJuego);
    }

    //Retorna la nueva cantidad de likes
    [HttpPost]
    public int LikesAjax(int IdJuego, int cantLikes, int IdUsuario)
    {
        BD.ActualizarLikesJuegoSP(IdJuego, cantLikes);
        // BD.ActualizarLikePersona(IdJuego, IdUsuario);
        return BD.VerCantLikes(IdJuego);
    }

    public IActionResult CrearCuentaAjax(Usuario usuario)
    {
        BD.AgregarUsuarioSP(usuario);
        //no se que poner
        return View("Index");

    }

    public IActionResult VerCarrito()
    {
        // forma de obtener el ID de usuario en tu aplicación
        // Obtén los juegos en el carrito para el usuario actual
        var carrito = BD.BuscarJuegosCarrito(idUsuario);
        return View(carrito);
    }

    public IActionResult AgregarAlCarrito(int idJuego)
    {
        // forma de obtener el ID de usuario en tu aplicación
        // Agrega el juego al carrito con una cantidad predeterminada
        BD.AgregarJuegoAlCarrito(idUsuario, idJuego, cantidad:); //agregarle la cantidad
        return RedirectToAction("PaginaPrincipal", "Home");
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}