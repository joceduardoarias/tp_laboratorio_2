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
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextWriter writer = new StreamWriter(archivo);
                serializer.Serialize(writer, datos);
                writer.Close();
                flag = true;
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
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextReader writer = new StreamReader(archivo);
                datos = (T)serializer.Deserialize(writer);
                writer.Close();

                flag = true;
            }
            catch (Exception e)
            {
                datos = default(T);
                throw new ArchivosException(e);
            }
            return flag;
        }
    }

}
