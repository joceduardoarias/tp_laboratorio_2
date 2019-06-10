using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.IO;
using System.Xml.Serialization;
namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

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
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        public Jornada this[int index]
        {
            get
            {
                return this.jornada.ElementAt(index);
            }
            set
            {
                this.jornada.Insert(index, value);
            }
        }
        #endregion

        #region CONSTRUCTOR
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region METODOS
        public static bool Guardar(Universidad uni)
        {
            bool flag = false;
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
               if(xml.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", uni))
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
        public static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada item in uni.jornada)
            {
                sb.AppendFormat(item.ToString());
                sb.AppendLine("< ------------------------------------------------------------------- >");
            }
            return sb.ToString();
        }
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool flag = false;
            // if(!ReferenceEquals(g,null)&&ReferenceEquals(a,null))
            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool flag = false;
            foreach (Jornada item in g.jornada)
            {
                if (item.Instructor == i)
                {
                    flag = true;
                }
            }
            return flag;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {

            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {//primero elegir un prfesor que dicte esa clase
                

            Jornada jornada;
            foreach (Profesor item in g.profesores)
            {
                if (item == clase)
                {
                    jornada = new Jornada(clase, item);

                    foreach (Alumno alumno in g.alumnos)
                    {
                        if(alumno == clase)
                        {
                            jornada.Alumnos.Add(alumno);
                        }
                    }
                    g.jornada.Add(jornada);
                }
                else
                {
                    throw new SinProfesorException();
                }
            }
            return g;
        }
        public static Universidad operator +(Universidad g, Alumno a)
        {
            bool flag = false;
            if (g.Alumnos.Count == 0)
            {
                g.Alumnos.Add(a);
            }
            else
            {
                foreach (Alumno item in g.alumnos)
                {
                    if (item != a)
                    {
                        g.Alumnos.Add(a);
                        break;
                    }
                    else
                    {
                        throw new AlumnoRepetidoException();
                    }
                }
            }

            return g;
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {

            if (g != i)
            {
                g.Instructores.Add(i);
            }

            return g;
        }
        #endregion

    }
}
