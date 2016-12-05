namespace Tns.Aerolinea.Application.DTO.Reserva
{
    public class TarifaDTO
    {
        public long IdVuelo { get; set; }
        public int IdTipoAsiento { get; set; }
        public string TipoAsiento { get; set; }
        public decimal ValorTiquete { get; set; }
    }
}