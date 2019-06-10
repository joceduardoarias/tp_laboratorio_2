using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using Excepciones;
namespace ClasesInstanciables
{
   public class Jornada
    {
        
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region PROPIEDADES
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public Universidad.EClases Clases
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region CONSTRUCTORES
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Clases = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region METDOS
        /// <summary>
        /// Guarda la informacion de una Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"> Jornada a guardar </param>
        /// <returns> true si pudo guardarse, false si ocurrio un error</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool flag = false;
            try
            {
                Texto texto = new Texto();
                if (texto.Guardar("Jornada", jornada.ToString()))
                {
                    flag = true;
                }
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            return flag;
        }
        /// <summary>
        /// Lee la informacion de una Jornada desde un archivo de texto y la trae para ser mostrada
        /// </summary>
        /// <returns> Informacion de la Jornada como texto </returns>
        public static string Leer()
        {
            string retorno = " ";
            if (!File.Exists("Jornada"))
            {
                Texto texto = new Texto();
                texto.Leer("Jornada.txt", out retorno);
            }
            return retorno;
        }
        /// <summary>
        /// Una Jornada sera igual a un Alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j"> Jornada  </param>
        /// <param name="a"> Alumno </param>
        /// <returns>true si el alumno participa de la clase, false si no participa de esta</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool flag = false;
            if(j.Alumnos.Contains(a))
            {
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// Una Jornada sera distinta a un Alumno si el mismo no participa de la clase
        /// </summary>
        /// <param name="j"> Jornada </param>
        /// <param name="a"> Alumno </param>
        /// <returns>true si el alumno no participa de la clase, false si participa de esta</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega alumnos a la clase de la Jornada
        /// </summary>
        /// <param name="j"> Jornada </param>
        /// <param name="a"> Alumno a agregar </param>
        /// <returns> Jornada </returns>
        public static Jornada operator +(Jornada j,Alumno a)
        {
          if(j!=a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        /// <summary>
        /// Muestra los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            sb.AppendLine("CLASE DE " + this.clase + " POR " + this.instructor);
            sb.AppendLine("ALUMNOS");
            foreach (Alumno item in this.Alumnos)
            {
                sb.Append(item);
            }
            sb.AppendLine("<------------------------------------------------>");
            return sb.ToString();
        }
        #endregion
    }
}
