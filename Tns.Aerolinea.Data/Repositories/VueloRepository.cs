namespace Tns.Aerolinea.Data.Repositories
{
    using Application.DTO.Reserva;
    using Domain.RepositoriesContracts;
    using Entities.Filter;
    using Model;
    using System.Collections.Generic;
    using System.Linq;

    public class VueloRepository : IVueloRepository
    {
        #region IVueloRepository Implementation

        /// <summary>
        /// Consulta de vuelos entre dos ciudades.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<VueloDTO> ConsultarVuelo(VueloCiudadFilter filtro)
        {
            List<VueloDTO> listaVuelos = new List<VueloDTO>();

            using (AerolineaTnsEntities context = new AerolineaTnsEntities())
            {
                var vuelos = context.Vuelo.Where(vuelo => vuelo.IdOrigen == filtro.IdOrigen && vuelo.IdDestino == filtro.IdDestino);

                listaVuelos = vuelos.Select(vuelo => new VueloDTO()
                {
                    Aerolinea = vuelo.Aerolinea.Nombre,
                    AeropuertoDestino = vuelo.Destino.Aeropuerto,
                    AeropuertoOrigen = vuelo.Origen.Aeropuerto,
                    CiudadDestino = vuelo.Destino.Ciudad.NombreCiudad,
                    CiudadOrigen = vuelo.Origen.Ciudad.NombreCiudad,
                    IdAerolinea = vuelo.IdAerolinea,
                    IdDestino = vuelo.IdDestino,
                    IdOrigen = vuelo.IdOrigen,
                    IdVuelo = vuelo.IdVuelo,
                    Salida = vuelo.Salida,
                    Fecha = vuelo.Fecha,
                    IdEstado = vuelo.IdEstado,
                    NombreEstado = vuelo.EstadoVuelo.NombreEstado,
                    Tarifas = vuelo.Tarifa.Select(tarifa => new TarifaDTO()
                    {
                        IdTipoAsiento = tarifa.IdTipoAsiento,
                        IdVuelo = vuelo.IdVuelo,
                        TipoAsiento = tarifa.TipoAsiento.Nombre,
                        ValorTiquete = tarifa.ValorTiquete
                    }).ToList(),
                }).ToList();
            }

            return listaVuelos;
        }

        /// <summary>
        /// Consultar el estados de los vuelos entre dos ciudades.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<EstadoVueloDTO> ConsultarEstadosVuelo(VueloCiudadFilter filtro)
        {
            List<EstadoVueloDTO> listaVuelos = new List<EstadoVueloDTO>();

            using (AerolineaTnsEntities context = new AerolineaTnsEntities())
            {
                var vuelos = context.Vuelo.Where(vuelo => vuelo.IdOrigen == filtro.IdOrigen && vuelo.IdDestino == filtro.IdDestino);

                listaVuelos = vuelos.Select(vuelo => new EstadoVueloDTO()
                {
                    Aerolinea = vuelo.Aerolinea.Nombre,
                    AeropuertoDestino = vuelo.Destino.Aeropuerto,
                    AeropuertoOrigen = vuelo.Origen.Aeropuerto,
                    CiudadDestino = vuelo.Destino.Ciudad.NombreCiudad,
                    CiudadOrigen = vuelo.Origen.Ciudad.NombreCiudad,
                    IdAerolinea = vuelo.IdAerolinea,
                    IdDestino = vuelo.IdDestino,
                    IdOrigen = vuelo.IdOrigen,
                    IdVuelo = vuelo.IdVuelo,
                    Salida = vuelo.Salida,
                    Fecha = vuelo.Fecha,
                    IdEstado = vuelo.IdEstado,
                    NombreEstado = vuelo.EstadoVuelo.NombreEstado,
                    AsientosDisponibles = vuelo.Avion.Asiento
                            .Where(asiento =>
                                !(vuelo.Reserva.Where(item => item.IdVuelo == vuelo.IdVuelo).FirstOrDefault().TiquetePasajero.Select(tiquete => tiquete.Asiento.IdAsiento).ToList()).Contains(asiento.IdAsiento))
                            .Select(asientodto => new AsientoDTO()
                            {
                                Codigo = asientodto.Codigo,
                                IdAsiento = asientodto.IdAsiento,
                                IdTipoAsiento = asientodto.IdTipoAsiento,
                                SalidaEmergencia = asientodto.SalidaEmergencia,
                                TipoAsiento = asientodto.TipoAsiento.Nombre
                            }).ToList(),
                }).ToList();
            }

            return listaVuelos;
        }

        #endregion IVueloRepository Implementation
    }
}