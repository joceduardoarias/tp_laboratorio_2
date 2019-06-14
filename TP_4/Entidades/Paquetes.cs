using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Paquetes:IMostrar<Paquetes>
    {   
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region PROPIEDADES
        public string DireccionEntrega
        {
            get
            {
            return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
            this.estado = value;
            }
        }
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
              this.trackingID = value;
            }
        }
        #endregion

        #region CONSTRUCTOR
        public Paquetes(string direccionEntrega,string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        #region METODOS
        public void MockCicloDeVida()
        {

        }
        public string MostrarDatos(IMostrar<Paquetes> elemento)
        {
            throw new NotImplementedException();
        }
        public static bool operator ==(Paquetes p1,Paquetes p2)
        {
            bool flag = false;

            return flag;
        }
        public static bool operator !=(Paquetes p1, Paquetes p2)
        {
            return true;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

    }
}
