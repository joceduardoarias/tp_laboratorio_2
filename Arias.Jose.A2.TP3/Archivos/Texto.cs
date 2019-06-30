using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
namespace Archivos
{
    public class Texto : IArchivo<string> 
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            
            try
            {
                StreamWriter fichero;
                fichero = new StreamWriter(archivo);
                fichero.WriteLine(datos);
                fichero.Close();
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            StreamReader streamReader;
            try
            {
                streamReader = new StreamReader(archivo);
                datos = streamReader.ReadToEnd();
                streamReader.Close();
                retorno = true;

            }
            catch (Exception e)
            {
                datos = String.Empty;
                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}
