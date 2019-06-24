using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Entidades
{
    public class Correo : IMostrar<List<Paquetes>>
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
            StringBuilder sb = new StringBuilder();
            foreach (Paquetes item in ((Correo)elemento).paquetes)
            {
                sb.Append(item.TrackingID.ToString() + " ");
                sb.Append(item.DireccionEntrega.ToString() + " ");
                sb.Append("(" + item.Estado.ToString() + ").\n");
            }
            return sb.ToString();
        }
        public void FinEntrega()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item.IsAlive)
                {
                    item.Abort();
                }
            }
        }
        /// <summary>
        /// Agrega un paquete al correo siempre que este no posea un trackingID repetido
        /// </summary>
        /// <param name="c"> Correo </param>
        /// <param name="p"> Paquete a agregar </param>
        /// <returns> Correo </returns>
        public static Correo operator +(Correo c, Paquetes p)
        {
           
            if (c.paquetes.Count == 0)
            {   
                
                c.paquetes.Add(p);
            }
            else
            {
                foreach (Paquetes item in c.paquetes)
                {
                    if (item == p)
                    {
                        
                        throw new TrackinIdrepetidoException("El paquete ya existe");
                    }
                    
                }
                c.paquetes.Add(p);
            }
            
            Thread thread = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(thread);
            thread.Start();
            return c;
        }
        #endregion
    }
}
