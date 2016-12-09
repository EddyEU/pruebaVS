namespace Tns.Aerolinea.Application.DTO.DatosMaestros
{
    public class CiudadDestinoDTO
    {
        public int IdCiudad { get; set; }
        public int IdDestino { get; set; }
        public string Ciudad { get; set; }
        public string Aeropuerto { get; set; }

        public string NombreLista
        {
            get { return Ciudad + " (" + Aeropuerto + ")"; }
        }
    }
}