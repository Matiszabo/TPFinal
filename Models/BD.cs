using System.Runtime.InteropServices.ComTypes;
using System.IO.Compression;
using System.Security.Cryptography;
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;



namespace TPFinal.Models
{
    public class BD
    {
        private static string _connectionString = @"Server=localhost;DataBase=CuboGames;Trusted_Connection=True;";
        private static List<Juego> listaJuegos = new List<Juego>();
        private static List<Categoria> listaCategorias = new List<Categoria>();

        public static List<Juego> TraerJuegos()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * from Juegos";
                listaJuegos = db.Query<Juego>(sql).ToList();
            }
            return listaJuegos;
        }
        public static List<Categoria> TraerCategorias()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * from Categorias";
                listaCategorias = db.Query<Categoria>(sql).ToList();
            }
            return listaCategorias;
        }
        public static Juego verInfoJuego(int idJ)
        {
            Juego juegoActual = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Juegos WHERE IdJuego = @pidJuego";
                juegoActual = db.QueryFirstOrDefault<Juego>(sql, new { pidJuego = idJ });
            }
            return juegoActual;
        }
        public static void AgregarJuegoSP(Juego Jug)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute("sp_AgregarJuego", new
                {
                    Nombre = Jug.Nombre,
                    CantLikes = Jug.CantLikes,
                    Descripcion = Jug.Descripcion,
                    FechaCreacion = Jug.FechaCreacion,
                    Imagen = Jug.Imagen,
                    Precio = Jug.Precio,
                    fkCategoria = Jug.fkCategoria
                }, commandType: CommandType.StoredProcedure);
            }
        }
        public static int VerificarSiExisteTarjeta (Tarjeta T)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Tarjeta WHERE Numero = @pNumero";
                return db.QueryFirstOrDefault<int>(sql, new { pNumero = Numero });
            }
        }    public IActionResult VerificatTarjeta(Tarjeta T)
    {
        Tarjeta tarjetaBD = BD.VerificarSiExisteTarjeta;
        return RedirectToAction("Compra", "Home");
    }
        public IActionResult Compra()
        {
            return View();
        }
        public static int ActualizarLikesJuegoSP(int idJuego, int cantLikes)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string idJuegoStr = idJuego.ToString();
                return db.Execute("sp_ActualizarLikesJuego", new
                {
                    IdJuego = idJuegoStr,
                    CantLikes = cantLikes
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public static int VerCantLikes(int idJ)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT CantLikes FROM Juegos WHERE IdJuego = @pIdJuego";
                return db.QueryFirstOrDefault<int>(sql, new { pIdJuego = idJ });
            }
        }

        public static int AgregarUsuarioSP(Usuario usuario)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                return db.Execute("sp_AgregarUsuario", new
                {
                    Contraseña = usuario.Contraseña,
                    Nombre = usuario.Nombre
                }, commandType: CommandType.StoredProcedure);
            }
        }
        public static Usuario BuscarUsuario(Usuario U)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Usuarios WHERE IdUsuario = @U.IdUsuario";
                return db.QueryFirstOrDefault<Usuario>(sql);
            }
        }
        public static Usuario BuscarUsuarioXNombre(string nombre)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Usuarios WHERE Nombre = @Nombre";
                return db.QueryFirstOrDefault<Usuario>(sql, new{ Nombre = nombre });
            }
        }
        public static Usuario BuscarContraXUsuario(string nombre)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Contraseña FROM Usuarios WHERE Nombre = @Nombre";
                return db.QueryFirstOrDefault<Usuario>(sql, new{ Nombre = nombre });
            }
        }


    }
}