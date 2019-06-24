using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Entidades
{
    public class Paquetes : IMostrar<Paquetes>
    {

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;
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
        public Paquetes(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        #region METODOS
        public void MockCicloDeVida()
        {
            do
            {
                InformaEstado(this.estado, EventArgs.Empty);
                Thread.Sleep(400);
                this.estado++;
                InformaEstado(this.Estado, EventArgs.Empty);
            } while ((int)this.Estado < 3);
           // InformaEstado(this.estado, EventArgs.Empty);

            //Thread.Sleep(400);
            //this.estado = EEstado.Ingresado;
            //InformaEstado(this.Estado, EventArgs.Empty);
            //Thread.Sleep(400);
            //this.estado = EEstado.EnViaje;
            //InformaEstado(this.Estado, EventArgs.Empty);
            //Thread.Sleep(400);
            //this.estado = EEstado.Entregado;
            //InformaEstado(this.Estado, EventArgs.Empty);
            PaqueteDAO.Insertar(this);
        }
        public string MostrarDatos(IMostrar<Paquetes> elemento)
        {
            return String.Format("{0} para {1}", ((Paquetes)elemento).trackingID, ((Paquetes)elemento).direccionEntrega);
        }
        public static bool operator ==(Paquetes p1, Paquetes p2)
        {
            bool flag = false;
            if (p1.TrackingID == p2.TrackingID)
            {
                flag = true;
            }
            return flag;
        }
        public static bool operator !=(Paquetes p1, Paquetes p2)
        {
            return !(p1 == p2);
        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

    }
}
