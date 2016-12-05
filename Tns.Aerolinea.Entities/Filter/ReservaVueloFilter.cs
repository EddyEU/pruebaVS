namespace Tns.Aerolinea.Entities.Filter
{
    using System;
    using System.Collections.Generic;

    public class ReservaVueloFilter
    {
        public int IdUsuario { get; set; }
        public long IdVuelo { get; set; }
        public DateTime FechaVuelo { get; set; }
        public List<TiquetePasajeroFilter> TiquetePasajero { get; set; }
    }
}