using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Entidades
{
   static class PaqueteDAO
    {
        private static SqlCommand SqlCommand;
        private static SqlConnection conexion;

        #region CONSTRUCTOR
        static PaqueteDAO()
        {

        }
        #endregion

        #region METDOS
        public static bool Insertar(Paquetes p)
        {
            return true;
        }
        #endregion
    }
}
