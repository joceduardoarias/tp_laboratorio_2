using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace FrmPpal
{
    public partial class Form1 : Form
    {
        Correo correo;
        public Form1()
        {
            InitializeComponent();
            correo = new Correo();
        }
        /// <summary>
        /// Muestra los paquetes y su estado actual y escribe en un archivo de texto en el escritorio esa informacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Agregar_Click(object sender, EventArgs e)
        {
            Paquetes paquetes = new Paquetes(textDireccion.Text, mtxtTrackingID.Text);
            paquetes.InformaEstado += new Paquetes.DelegadoEstado(Paq_InformaEstado);
            try
            {
                correo += paquetes;
            }
            catch (TrackinIdrepetidoException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            this.ActualizarEstados();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntrega();
        }
        private void Paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquetes.DelegadoEstado d = new Paquetes.DelegadoEstado(Paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }
        /// <summary>
        /// El método ActualizarEstados limpiará los 3 ListBox y luego recorrerá
        /// la lista de paquetes agregando cada uno de ellos en el listado que corresponda
        /// </summary>
        private void ActualizarEstados()
        {

            foreach (Paquetes item in correo.Paquetes)
            {
                if (item.Estado == Paquetes.EEstado.Ingresado)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(item.ToString());

                }
                if (item.Estado == Paquetes.EEstado.EnViaje)
                {
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox2.Items.Add(item.ToString());

                }
                if (item.Estado == Paquetes.EEstado.Entregado)
                {
                    listBox2.Items.Clear();
                    lstEstadoEntregado.Items.Clear();
                    lstEstadoEntregado.Items.Add(item);

                }
            }
        }

        /// <summary>
        /// Muestra los paquetes y su estado actual y escribe en un archivo de texto en el escritorio esa informacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquetes>>((IMostrar<List<Paquetes>>)correo);
        }
        /// <summary>
        /// Muestra uno o todos los paquetes y su estado actual
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Salida.txt";
            if (elemento != null)
            {
                if (elemento is Paquetes)
                {

                    richTextBox1.AppendText(((Paquetes)elemento).ToString());
                }
                else if (elemento is Correo)
                {
                    richTextBox1.Text = ((Correo)elemento).MostrarDatos((Correo)elemento);
                }
                richTextBox1.Text.Guardar(desktopPath);
            }

        }
        /// <summary>
        /// Muestra los paquetes y su estado actual y escribe en un archivo de texto en el escritorio esa informacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MostrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquetes>((IMostrar<Paquetes>)lstEstadoEntregado.SelectedItem);
        }


    }
}
