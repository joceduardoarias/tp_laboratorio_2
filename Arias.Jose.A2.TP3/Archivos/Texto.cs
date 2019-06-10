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
            StreamWriter text = new StreamWriter(archivo);
            if (!object.ReferenceEquals(text, null) && !object.ReferenceEquals(datos, null))
            {
                text.Write(datos);
                retorno = true;
            }
            else
            {
                throw new ArchivosException(new Exception());
            }
            text.Close();

            return retorno;
        }
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            StreamReader streamWriter;
            try
            {
                streamWriter = new StreamReader(archivo);
                datos = streamWriter.ReadToEnd();
                streamWriter.Close();
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
