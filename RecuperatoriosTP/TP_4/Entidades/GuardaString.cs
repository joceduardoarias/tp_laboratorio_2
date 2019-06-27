using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Entidades
{   
   public static class GuardaString
    {
        /// <summary>
        /// Este guardará en un archivo de texto en el escritorio de la máquina.
        /// </summary>
        /// <param name="texto">cadena que se escribira en el archivo</param>
        /// <param name="archivo">el nombre del archivo</param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool flag = false;
            try
            {
                StreamWriter fichero; 
                fichero = new StreamWriter(archivo,true);
                fichero.WriteLine(texto);
                fichero.Close();
                flag = true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return flag;
        }
        
    }
}
