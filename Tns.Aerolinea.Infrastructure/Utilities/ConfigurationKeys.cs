namespace Tns.Aerolinea.Infrastructure.Utilities
{
    using System;
    using System.Configuration;

    public class ConfigurationKeys
    {
        /// <summary>
        /// Obtener el AppSettings según la clave especificada
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetKeyAppSettings(string key)
        {
            try
            {
                return (!string.IsNullOrEmpty(key)) ? ConfigurationManager.AppSettings[key].ToString() : string.Empty;
            }
            catch
            {
                throw new NullReferenceException("El parámetro con clave (" + key + ") no fue encontrado en el archivo de configuración.");
            }
        }

        /// <summary>
        /// Obtener la cadena de conexión según la clave.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetKeyConnectionStrings(string key)
        {
            try
            {
                return (!string.IsNullOrEmpty(key)) ? ConfigurationManager.ConnectionStrings[key].ConnectionString : string.Empty;
            }
            catch
            {
                throw new NullReferenceException("La cadena de conexión con clave (" + key + ") no fue encontrada en el archivo de configuración.");
            }
        }
    }
}