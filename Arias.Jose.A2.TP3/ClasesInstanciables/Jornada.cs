using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
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
        //flata leer y guardar.
        public bool GuardarJornada(Jornada jornada)
        {
            bool flag = false;
            
            return flag;
        } 
        public string Leer()
        {
            return "";
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
            sb.AppendLine("<------------------------------------------------>");
            sb.AppendLine("CLASE DE " + this.clase.ToString() + " POR " + this.instructor.ToString());
            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        #endregion
    }
}
