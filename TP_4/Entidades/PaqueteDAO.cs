using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Entidades
{
   public static class PaqueteDAO
    {
        private static SqlCommand SqlCommand;
        private static SqlConnection conexion;

        #region CONSTRUCTOR
        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.conexion_bd);
        }
        #endregion

        #region METDOS
        public static bool Insertar(Paquetes p)
        {
            bool flag = false;
            string alumno = "Jose Arias";
            SqlCommand = new SqlCommand();
            try
            {
                SqlCommand.Connection = conexion;
                SqlCommand.CommandType = CommandType.Text;
                SqlCommand.CommandText = " insert into [correo-sp-2017].[dbo].[Paquetes](direccionEntrega,trackingID,alumno) values('" + p.DireccionEntrega + "','" + p.TrackingID + "','" + alumno + "')";
                conexion.Open();
                int valor = SqlCommand.ExecuteNonQuery();

                if (valor > 0)
                {
                    conexion.Close();
                    flag = true;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error acceso base de datos", e);
            }
            return flag;
            #endregion
        }
    }
}
