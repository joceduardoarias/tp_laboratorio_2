using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Entidades
{
   public class Correo: IMostrar<List<Paquetes>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquetes> paquetes;

        #region PROPIEDADES
        public List<Paquetes> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region CONSTRUCTOR
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquetes>();
        }
        #endregion

        #region METODOS
        public string MostrarDatos(IMostrar<List<Paquetes>> elemento)
        {
            throw new NotImplementedException();
        }
        public void FinEntrega()
        {

        }
        public static Correo operator +(Correo c,Paquetes p)
        {
            return c;
        }
        #endregion
    }
}
