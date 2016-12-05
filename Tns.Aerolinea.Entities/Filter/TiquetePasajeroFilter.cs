namespace Tns.Aerolinea.Entities.Filter
{
    public class TiquetePasajeroFilter
    {
        public decimal ValorTiquete { get; set; }
        public short IdTipoAsiento { get; set; }
        public PasajeroFilter Pasajero { get; set; }
    }
}