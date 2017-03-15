using System;

namespace Tns.Aerolinea.Application.DTO.Login
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Login { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}