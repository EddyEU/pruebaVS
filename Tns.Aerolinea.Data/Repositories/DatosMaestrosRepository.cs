namespace Tns.Aerolinea.Data.Repositories
{
    using Application.DTO.DatosMaestros;
    using Domain.DomainContracts;
    using Model;
    using System.Collections.Generic;
    using System.Linq;

    public class DatosMaestrosRepository : IDatosMaestrosRepository
    {
        /// <summary>
        /// Obtener el listado de orígenes de las aerolíneas.
        /// </summary>
        /// <returns></returns>
        public List<CiudadDestinoDTO> ConsultarDestinos()
        {
            var ciudadesDestino = new List<CiudadDestinoDTO>();

            using (AerolineaTnsEntities context = new AerolineaTnsEntities())
            {
                ciudadesDestino = context.Destino.Where(item => item.Activo).Select(destino => new CiudadDestinoDTO()
                {
                    IdCiudad = destino.IdCiudad,
                    Ciudad = destino.Ciudad.NombreCiudad,
                    IdDestino = destino.IdDestino,
                    Aeropuerto = destino.Aeropuerto
                }).ToList();
            }

            return ciudadesDestino;
        }

        /// <summary>
        /// Obtener el listado de destinos de las aerolíneas.
        /// </summary>
        /// <returns></returns>
        public List<CiudadOrigenDTO> ConsultarOrigenes()
        {
            var ciudadesOrigen = new List<CiudadOrigenDTO>();

            using (AerolineaTnsEntities context = new AerolineaTnsEntities())
            {
                ciudadesOrigen = context.Origen.Where(item => item.Activo).Select(destino => new CiudadOrigenDTO()
                {
                    IdCiudad = destino.IdCiudad,
                    Ciudad = destino.Ciudad.NombreCiudad,
                    IdOrigen = destino.IdOrigen,
                    Aeropuerto = destino.Aeropuerto
                }).ToList();
            }

            return ciudadesOrigen;
        }
    }
}