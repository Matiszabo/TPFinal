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
                string sql = "SELECT * FROM Usuarios WHERE ID_Usuario = @usuario.ID_Usuario";
                return db.QueryFirstOrDefault<Usuario>(sql);
            }
        }
        public static Usuario BuscarUsuarioXNombre(string nombre)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Usuarios WHERE nombre = @pnombre";
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
                string sql = "SELECT contraseña FROM Usuarios WHERE nombre = @pnombre";
                return db.QueryFirstOrDefault<Usuario>(sql, new{ pnombre = nombre });
            }
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
    
        public static Viajes SeleccionarViajesPorPais(int id)
        {
            Viajes Elegido = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string SQL = "SELECT * FROM Viajes WHERE Viajes.ID_Pais= @ID_Pais";
                Elegido = db.QueryFirstOrDefault<Viajes>(SQL, new { pid= id });
            }
            return Elegido;
        }
        public static void InsertViaje(Viajes viaje)
        {
            string SQL = "sp_InsertViajes";
            SQL += " VALUES (@pID_Viaje, @pnombre, @pprecio, @pimagen, @pdescripcion, @ppuntaje, @pID_Pais)";

            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(SQL, new
                {
                    pID_Viaje = viaje.ID_Viaje,
                    pnombre = viaje.nombre,
                    pprecio = viaje.precio,
                    pimagen = viaje.imagen,
                    pdescripcion = viaje.descripcion,
                    ppuntaje = viaje.puntaje,
                    pID_Pais = viaje.ID_Pais
                }
                );
            }
        }
        public static void InsertPais(Pais pais)
        {
            string SQL = "sp_InsertPais";
            SQL += "VALUES(@pID_Pais, @pnombre, @pDescripcion)";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(SQL, new
                {
                    pID_Pais = pais.ID_Pais,
                    pnombre = pais.nombre,
                    pDescripcion = pais.Descripcion
                }
                );
            }
        }
        public static void InsertUsuario(Usuario usuario)
        {
            string SQL = "sp_InsertUsuario";
            SQL += "VALUES(@pID_Usuario, @pnombre, @pemail, @pcontraseña, @pID_Viaje, @pFechaNacimiento)";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(SQL, new
                {
                    pID_Usuario = usuario.ID_Usuario,
                    pnombre = usuario.nombre,
                    pemail = usuario.email,
                    pcontraseña = usuario.contraseña,
                    pID_Viaje = usuario.ID_Viaje,
                    pFechaNacimiento = usuario.FechaNacimiento
                }
                );
            }
        }  
    }
}