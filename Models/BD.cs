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
        public static Tarjeta VerificarSiExisteTarjeta(int numero)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Tarjeta WHERE Numero = @pNumero";
                return db.QueryFirstOrDefault<Tarjeta>(sql, new { pNumero = numero});
            }
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
        public static List<CarritosResultados> BuscarJuegosCarrito(int idUsuario)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT dbo.Carritos.IdCarrito ,dbo.Carritos.Fecha, dbo.Juegos.Nombre, dbo.Juegos.CantLikes, dbo.Carritos.EstaFinalizado FROM dbo.Carritos INNER JOIN dbo.CarritosDetalle ON dbo.Carritos.IdCarrito = dbo.CarritosDetalle.IdCarrito INNER JOIN dbo.Juegos ON dbo.CarritosDetalle.IdJuego = dbo.Juegos.IdJuego WHERE Carritos.IdUsuario = @IdUsuario";
                return  db.Query<CarritosResultados> (sql, new{ IdUsuario = idUsuario }).ToList();
            }
        }
                
        

        public static void AgregarJuegoAlCarrito(int idUsuario, int idJuego, int cantidad)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Open();

                string sql = "SELECT IdCarrito FROM Carritos WHERE IdUsuario = @IdUsuario AND EstaFinalizado = 0";
                int? idCarrito = db.QueryFirstOrDefault<int?>(sql, new { IdUsuario = idUsuario });

                if (idCarrito == null)
                {
                    sql = "INSERT INTO Carritos (IdUsuario, Fecha, EstaFinalizado) VALUES (@IdUsuario, GETDATE(), 0); SELECT SCOPE_IDENTITY()";
                    idCarrito = db.QueryFirstOrDefault<int>(sql, new { IdUsuario = idUsuario });
                }

                sql = "SELECT IdCarritoDetalle FROM CarritosDetalle WHERE IdCarrito = @IdCarrito AND IdJuego = @IdJuego";
                int? idCarritoDetalle = db.QueryFirstOrDefault<int?>(sql, new { IdCarrito = idCarrito, IdJuego = idJuego });

                if (idCarritoDetalle != null)
                {
                    sql = "UPDATE CarritosDetalle SET Cantidad = Cantidad + @Cantidad WHERE IdCarritoDetalle = @IdCarritoDetalle";
                    db.Execute(sql, new { Cantidad = cantidad, IdCarritoDetalle = idCarritoDetalle });
                }
                else
                {
                    sql = "INSERT INTO CarritosDetalle (IdCarrito, IdJuego, Cantidad) VALUES (@IdCarrito, @IdJuego, @Cantidad)";
                    db.Execute(sql, new { IdCarrito = idCarrito, IdJuego = idJuego, Cantidad = cantidad });
                }

                db.Close();
            }
        }
    }
}