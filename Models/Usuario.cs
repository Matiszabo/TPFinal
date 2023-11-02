namespace Prac.Models
{
    public class Usuario
    {
        public int ID_Usuario { get;set;}
        public string nombre { get;set;}
        public string email {get;set;}
        public string contraseña {get;set;}
        public int ID_Viaje { get;set;}
        public DateTime FechaNacimiento { get;set;}
    }    
}
