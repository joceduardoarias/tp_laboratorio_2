using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
      
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region CONSTRUCTOR
        public Alumno()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region METODOS
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
           // sb.AppendFormat(base.MostrarDatos());
            sb.AppendFormat("\nClase que Toma:{0} ", this.claseQueToma);
            sb.AppendFormat("\nEstado Cuenta:{0} ", this.estadoCuenta);
            return sb.ToString();
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("TOMA CLASE DE {0}", this.claseQueToma);
            return sb.ToString();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.ToString());
            sb.AppendFormat(this.MostrarDatos());
            return sb.ToString();
        }
        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            bool flag = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                flag = true;
            }
            return flag;
        }
        public static bool operator !=(Alumno a,Universidad.EClases clase)
        {
            return !(a == clase);
        }
        #endregion
    }
}
