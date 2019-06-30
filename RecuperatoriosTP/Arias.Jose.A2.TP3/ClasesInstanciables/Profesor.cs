using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
namespace ClasesInstanciables
{
    public sealed class Profesor:Universitario
    {
        
        private Queue<Universidad.EClases> clasesDeDia;
        private static Random random;

        #region CONSTRUCTOR
        private Profesor()
        {

        }
        static Profesor()
        {
            random = new Random();
        }
        public Profesor(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDeDia = new Queue<Universidad.EClases>();
            this.Random();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Asigna clases a un Profesor
        /// </summary>
        private void Random()
        {
            this.clasesDeDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            System.Threading.Thread.Sleep(600);
            this.clasesDeDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }
        /// <summary>
        /// Recopila todos los datos de un Profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat( clasesDeDia.Peek().ToString());
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendFormat(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"> Profesor </param>
        /// <param name="clases"> Clase </param>
        /// <returns>true si da esa clase, false si no la da</returns>
        public static bool operator ==(Profesor i,Universidad.EClases clase)
        {
            bool flag = false;
            foreach (Universidad.EClases item in i.clasesDeDia)
            {
                if (item == clase)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        /// <summary>
        /// Un Profesor será distinto a un EClase si no da esa clase.
        /// </summary>
        /// <param name="i"> Profesor </param>
        /// <param name="clases"> Clase </param>
        /// <returns>true si no da esa clase, false si la da</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        /// <summary>
        /// Muestra las clases que da un Profesor
        /// </summary>
        /// <returns> cadena "CLASES DEL DÍA" junto al nombre de la clases que da </returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DEL DIA: ");
            foreach (Universidad.EClases item in this.clasesDeDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Hace publicos los datos de un Profesor
        /// </summary>
        /// <returns> informacion del Profesor </returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
