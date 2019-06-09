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
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool flag = false;
            if(j.Alumnos.Contains(a))
            {
                flag = true;
            }
            return flag;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j,Alumno a)
        {
          if(j!=a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
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
