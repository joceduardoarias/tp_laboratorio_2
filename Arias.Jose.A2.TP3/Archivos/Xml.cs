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
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool flag = false;
            StreamWriter streamWriter = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                streamWriter = new StreamWriter(archivo);
                xml.Serialize(streamWriter, datos);
                flag = true;

            }
            catch (Exception)
            {

                flag = false;
            }
            finally
            {
                streamWriter.Close();
            }
            return flag;
        }
        public bool Leer(string archivo, out T datos)
        {
            bool flag = false;
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(archivo);

                XmlSerializer xml = new XmlSerializer(typeof(T));
                datos = (T)xml.Deserialize(reader);
                flag = true;

            }
            catch (Exception)
            {
                flag = false;
                datos = default(T);
            }
            finally
            {
                reader.Close();
            }
            return flag;
        }
    }

}
