namespace Tns.Aerolinea.Application.DTO.Reserva
{
    public class AsientoDTO
    {
        public int IdAsiento { get; set; }
        public short IdTipoAsiento { get; set; }
        public string TipoAsiento { get; set; }
        public string Codigo { get; set; }
        public string SalidaEmergencia { get; set; }
    }
}