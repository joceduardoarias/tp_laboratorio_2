using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
  public abstract class Universitario:Persona
    {
        #region CAMPOS
        private int legajo;
        #endregion

        #region CONSTRUCTOR
        public Universitario()
        {

        }
        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region METODOS
        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj != null && obj is Universitario)
            {
                if(((Universitario)obj==this))
                flag = true;
            }
            return flag;
        }
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Legajo:{0}", this.legajo);
            sb.AppendFormat(base.ToString());
            return sb.ToString();
        }
        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            bool flag = false;
            if(pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI /*&& pg1.Equals(pg2)*/)
            {
                flag = true;
            }
            return flag;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        protected abstract string ParticiparEnClase();
        

        
        #endregion
    }
}
