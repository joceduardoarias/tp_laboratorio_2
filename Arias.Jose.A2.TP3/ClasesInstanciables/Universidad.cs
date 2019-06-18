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
        /// <summary>
        /// Serializa los datos de una Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="uni"> Universidad </param>
        /// <returns> True si puede guardar el archivo </returns>
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
        /// <summary>
        /// Recopila datos de una Universidad
        /// </summary>
        /// <param name="uni"> Universidad </param>
        /// <returns></returns>
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
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="a"> Alumno </param>
        /// <returns> true si esta inscripto en la universidad, false si no lo esta</returns>
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
        /// <summary>
        /// Un Universidad será distinto a un Alumno si el mismo no esta inscripto en él.
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="a"> Alumno </param>
        /// <returns> true si no esta inscripto en la universidad, false si lo esta </returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="i"> Profesor </param>
        /// <returns> true si el profesor da clases alli, false si no las da </returns>
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
        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo no está dando clases en él.
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="i"> Profesor </param>
        /// <returns> true si el profesor no da clases alli, false si las da  </returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Retorna el primer Profesor capaz de dar esa clase.
        /// </summary>
        /// <param name="u"> Universidad </param>
        /// <param name="clase"> Clase </param>
        /// <returns> Profesor capaz de dar la clase </returns>
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
        /// <summary>
        /// Retorna el primer Profesor que no pueda dar esa clase.
        /// </summary>
        /// <param name="u"> Universidad </param>
        /// <param name="clase"> Clase </param>
        /// <returns> Profesor que no da la clase </returns>
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
        /// <summary>
        /// Hace publicos los datos de una Universidad
        /// </summary>
        /// <returns>datos de la Universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Agrega una clase con su respectiva jornada y alumnos que la cursan
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="clase"> Clase </param>
        /// <returns> Universidad </returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
                

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
        /// <summary>
        /// Agrega un alumno a la Universidad validando que no este previamente cargado
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="a"> Alumno </param>
        /// <returns> Universidad </returns>
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
        /// <summary>
        /// Agrega un profesor a la Universidad validando que no este previamente cargado
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="i"> Profesor </param>
        /// <returns> Universidad </returns>
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
