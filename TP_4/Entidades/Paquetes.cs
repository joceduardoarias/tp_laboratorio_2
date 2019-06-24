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
        /// <summary>
        /// Cambia e informa el estado de los paquetes ingresados al correo
        /// </summary>
        public void MockCicloDeVida()
        {

            do
            {
                InformaEstado(this.estado, EventArgs.Empty);
                Thread.Sleep(400);
                this.estado++;
                //int estado = (int)this.Estado + 1;
                InformaEstado((EEstado)estado, EventArgs.Empty);
            } while (this.Estado != EEstado.Entregado);
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                InformaEstado(e, EventArgs.Empty);
            }

        }
        /// <summary>
        /// Muestra los datos del paquete con un formato especifico
        /// </summary>
        /// <param name="elemento"> Elemento a ser mostrado </param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquetes> elemento)
        {
            return String.Format("{0} para {1}", ((Paquetes)elemento).trackingID, ((Paquetes)elemento).direccionEntrega);
        }
        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo.
        /// </summary>
        /// <param name="p1"> Paquete </param>
        /// <param name="p2"> Paquete </param>
        /// <returns></returns>
        public static bool operator ==(Paquetes p1, Paquetes p2)
        {
            bool flag = false;
            if (p1.TrackingID == p2.TrackingID)
            {
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// Dos paquetes serán distintos siempre y cuando su Tracking ID no sea el mismo.
        /// </summary>
        /// <param name="p1"> Paquete </param>
        /// <param name="p2"> Paquete </param>
        /// <returns></returns>
        public static bool operator !=(Paquetes p1, Paquetes p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// Devuelve la información del paquete.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

    }
}
