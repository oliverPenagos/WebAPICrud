using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICrud.Core.Helpers
{
    public class ContextConfiguration
    {
        #region Constructor
        /// <summary>
        /// Iniciliza los atributos de la clase
        /// </summary>
        /// ‹param name="conexion">Cadena de conexión para el datacontext de la aplicación‹/param>
        public ContextConfiguration(string conexion)
        { 
            ConexionString = conexion;

        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o asigna la cadena de conexión para el datacontext de la aplicación
        /// </summary>

        public static string? ConexionString { get; set; }

        #endregion

        #region Metodos
        /// <summary>
        /// Obtiene el objeto DbContextOptions con la conexion de datos.
        /// <summary>
        /// <param name="conexionString">Cadena de conexion.</param>
        /// <returns>DbContextOptions</returns>
        
        public static DbContextOptions GetOptions(string conexionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), conexionString).Options;
        }

        #endregion
    }
}
