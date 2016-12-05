namespace Tns.Aerolinea.Application.DTO.Reserva
{
    using System;
    using System.Collections.Generic;

    public class ReservaDTO
    {
        public long IdReserva { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public long IdVuelo { get; set; }
        public int IdOrigen { get; set; }
        public string CiudadOrigen { get; set; }
        public int IdDestino { get; set; }
        public string CiudadDestino { get; set; }
        public string Aerolinea { get; set; }
        public DateTime FechaVuelo { get; set; }
        public decimal ValorTotalReserva { get; set; }
        public DateTime FechaReserva { get; set; }
        public List<PasajeroDTO> Pasajeros { get; set; }
    }
}