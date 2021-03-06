﻿namespace Tns.Aerolinea.Application.DTO.Reserva
{
    using System;
    using System.Collections.Generic;

    public class VueloDTO
    {
        public long IdVuelo { get; set; }
        public int IdOrigen { get; set; }
        public string CiudadOrigen { get; set; }
        public string AeropuertoOrigen { get; set; }
        public int IdDestino { get; set; }
        public string CiudadDestino { get; set; }
        public string AeropuertoDestino { get; set; }
        public int IdAerolinea { get; set; }
        public string Aerolinea { get; set; }
        public DateTime Fecha { get; set; }
        public List<TarifaDTO> Tarifas { get; set; }
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }
    }
}