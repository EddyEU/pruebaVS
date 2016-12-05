namespace Tns.Aerolinea.Infrastructure.Excepciones
{
    using System;

    public class BussinesException : Exception
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesException con un mensaje especificado.
        /// </summary>
        /// <param name="mensajeExcepcion">Mensaje que describe el error.</param>
        public BussinesException(string mensajeExcepcion)
            : base(mensajeExcepcion)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesException con un mensaje especificado.
        /// </summary>
        /// <param name="format">Formato del mensaje.</param>
        /// <param name="args">Colección de objetos que contiene 0 o mas objetos para anexar al mensaje.</param>
        public BussinesException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        #endregion Constructor
    }
}