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
        private void Random()
        {
            this.clasesDeDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            System.Threading.Thread.Sleep(600);
            this.clasesDeDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Universidad.EClases item in this.clasesDeDia)
            {
                sb.AppendFormat("Clase:{0}", item.ToString());
            }
            return sb.ToString();
        }
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
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DEL DIA:{0}", this.clasesDeDia);
            return sb.ToString();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(this.MostrarDatos());
            sb.AppendFormat(base.MostrarDatos());
            return sb.ToString();
        }
        #endregion
    }
}
