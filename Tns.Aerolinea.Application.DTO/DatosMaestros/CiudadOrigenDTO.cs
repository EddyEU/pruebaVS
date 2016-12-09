namespace Tns.Aerolinea.Application.DTO.DatosMaestros
{
    public class CiudadOrigenDTO
    {
        public int IdCiudad { get; set; }
        public int IdOrigen { get; set; }
        public string Ciudad { get; set; }
        public string Aeropuerto { get; set; }

        public string NombreLista
        {
            get { return Ciudad + " (" + Aeropuerto + ")"; }
        }
    }
}