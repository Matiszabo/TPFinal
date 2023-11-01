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
public static void InsertViaje(Viaje viaje)
{
    string SQL = "INSERT INTO Viaje(ID_Viaje, nombre, precio, imagen, descripcion, puntaje, ID_Pais)";
    SQL += " VALUES (@pID_Viaje, @pnombre, @pprecio, @pimagen, @pdescripcion, @ppuntaje, @pID_Pais)";

    using (SqlConnection db = new SqlConnection(_connectionString))
    {
        db.Execute(SQL, new
        {
            pID_Viaje = viaje.ID_Viaje,
            pnombre = viaje.nombre,
            pprecio = viaje.precio,
            pimagen = viaje.imagen
            pdescripcion = viaje.descripcion
            ppuntaje = viaje.puntaje
            pID_Pais = viaje.ID_Pais
        });
    }
}


    
    }
}