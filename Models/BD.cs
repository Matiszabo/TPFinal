using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
namespace Prac.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=localhost;DataBase=Wanderlust;Trusted_Connection=True;";

        public static Usuario BuscarUsuario(Usuario usuario)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Usuario WHERE ID_Usuario = @usuario.ID_Usuario";
                return db.QueryFirstOrDefault<Usuario>(sql);
            }
        }
        public static Usuario BuscarUsuarioXNombre(string nombre)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Usuario WHERE nombre = @pnombre";
                return db.QueryFirstOrDefault<Usuario>(sql, new{ pnombre = nombre });
            }
        }
        public static Usuario LoginIngresado(string usuario, string contraseña)
        {
            Usuario Ingresado = new Usuario();
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string SQL = "SELECT * FROM Usuario WHERE usuario= @pUsuario and contraseña= @pContraseña";
                Ingresado = db.QueryFirstOrDefault<Usuario>(SQL, new { pUsuario = usuario, pContraseña = contraseña});
            }
            return Ingresado;
        }
        public static Usuario BuscarContraXUsuario(string nombre)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT contraseña FROM Usuario WHERE nombre = @pnombre";
                return db.QueryFirstOrDefault<Usuario>(sql, new{ pnombre = nombre });
            }
        }

        public static Usuario usuarioElegido(int ID_Usuario)
        {
            Usuario Elegido = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string SQL = "SELECT * FROM Usuario WHERE ID_Usuario= @pID_Usuario";
                Elegido = db.QueryFirstOrDefault<Usuario>(SQL, new { pID_Usuario= ID_Usuario });
            }
            return Elegido;
        }

        public static List<Pais> SeleccionarPaises()
        {
            List<Pais> ListaPaises;
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Pais";
                ListaPaises = db.Query<Pais>(sql).ToList();
            }
            return ListaPaises;
        }
    
            public static List<Viajes> SeleccionarViajesPorPais(int id)
            {
                List<Viajes> ListaViajes;
             using (SqlConnection db = new SqlConnection(_connectionString))
             {
              string SQL = "SELECT * FROM Viajes WHERE ID_Pais= @pID_Pais";
               ListaViajes = db.Query<Viajes>(SQL, new { pID_Pais = id }).ToList();
               }
               return ListaViajes;
            }
        public static List<Usuario> SeleccionarUsuarios()
        {
            List<Usuario> ListaUsuarios;
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Alumnos";
                ListaUsuarios = db.Query<Usuario>(sql).ToList();
            }
            return ListaUsuarios;
        }
        
        public static void InsertViaje(Viajes viaje)
        {
            string SQL = "sp_InsertViajes";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(SQL, new
                {
                    nombre = viaje.nombre,
                    precio = viaje.precio,
                    imagen = viaje.imagen,
                    descripcion = viaje.descripcion,
                    puntaje = viaje.puntaje,
                    ID_Pais = viaje.ID_Pais
                }
                );
            }
        }
        public static void InsertPais(Pais pais)
        {
            string SQL = "sp_InsertPais";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(SQL, new
                {
                    nombre = pais.nombre,
                    Descripcion = pais.Descripcion
                }
                );
            }
        }
        public static void InsertUsuario(Usuario usuario)
        {
            string SQL = "sp_InsertUsuario";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(SQL, new
                {
                    nombre = usuario.nombre,
                    usuario = usuario.usuario,
                    email = usuario.email,
                    contraseña = usuario.contraseña,
                    FechaNacimiento = usuario.FechaNacimiento
                }
                );
            }
        }  
    }
}