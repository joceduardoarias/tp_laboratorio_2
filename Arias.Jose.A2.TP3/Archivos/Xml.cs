using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;
namespace Archivos
{
    public class Xml<T>: IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool flag = false;

            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                StreamWriter streamWriter = new StreamWriter(archivo);
                xml.Serialize(streamWriter, datos);
                flag = true;
                streamWriter.Close();
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            return flag;
        }
       public bool Leer(string archivo, out T datos)
        {
            bool flag = false;
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    datos = (T)xml.Deserialize(reader);
                    flag = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return flag;
        }
    }

}
