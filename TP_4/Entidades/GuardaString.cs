using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Entidades
{   //La clase donde se guardan las extensiones debe ser estatica
    static class GuardaString
    {

        //El metodo que se extiende debe ser estatico
        //El primer parametro lleva this y representa el tipo que estamos extendiendo
        /// <summary>
        /// Este guardará en un archivo de texto en el escritorio de la máquina.
        /// </summary>
        /// <param name="texto">cadena que se escribira en el archivo</param>
        /// <param name="archivo">el nombre del archivo</param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool flag = false;
            if(File.Exists(archivo))
            {
                StreamWriter fichero; 
                fichero = new StreamWriter(archivo);
                fichero.WriteLine(texto);
                fichero.Close();
            }
            return flag;
        }
    }
}
