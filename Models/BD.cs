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
        private static string _connectionString = @"Server=A-PHZ2-CIDI-019; DataBase=CuboGames;Trusted_Connection=True;";

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
        public static void AgregarJuego(Juego Jug)
        {
            int registrosInsertados = 0;
            string sql = "INSERT INTO Juegos(Nombre, CantLikes, Descripcion, FechaCreacion, Imagen, Precio, fkCategoria) VALUES(@Nombre, @CantLikes, @Descripcion, @FechaCreacion, @Imagen, @Precio, @fkCategoria)";

            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { Nombre = Jug.Nombre, CantLikes = Jug.CantLikes, Descripcion = Jug.Descripcion, FechaCreacion = Jug.FechaCreacion, Imagen = Jug.Imagen, Precio = Jug.Precio, fkCategoria = Jug.fkCategoria });
            }
        }

        public static int AgregarLikes(int idJ, int cantLikes)
        {
            int registrosInsertados = 0;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Juegos SET CantLikes = (CantLikes + @pcantLikes) WHERE IdJuego = @pidJuego";
                registrosInsertados = db.Execute(sql, new { pIdJuego = idJ, pcantLikes = cantLikes });
            }
            if (cantLikes == 1)
            {
                string SQL = "DELETE FROM LikesxUsuario WHERE IdUsuario";
            }
            return registrosInsertados;
        }

        public static int VerCantLikes(int idJ)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT CantLikes FROM Juegos WHERE IdJuego = @pIdJuego";
                return db.QueryFirstOrDefault<int>(sql, new { pIdJuego = idJ });
            }
        }

        public static int AgregarUsuario(Usuario usuario)
        {
            int registrosInsertados = 0;
            string sql = "INSERT INTO Usuarios(Contraseña, Nombre) VALUES(@Contraseña, @Nombre)";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                registrosInsertados = db.Execute(sql, new { Contraseña = usuario.Contraseña, Nombre = usuario.Nombre });
            }
            return registrosInsertados;
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