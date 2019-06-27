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
namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private static double Operate(string n1, string n2, string operador)
        {

            Numero numeroUno;
            numeroUno = new Numero(n1);
            Numero numeroDos;
            numeroDos = new Numero(n2);
            double retorno;
            retorno = Calculadora.Operar(numeroUno, numeroDos, operador);
            return retorno;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Operar_Click(object sender, EventArgs e)
        {
            SalidaRespuesta.Text = Operate(textBox1.Text, textBox2.Text, comboBox1.Text).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("/");
            comboBox1.Items.Add("*");
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            SalidaRespuesta.Text = " ";
            comboBox1.Text = "";

        }

        private void ConvertDecimal_Click(object sender, EventArgs e)
        {
            Numero numero;
            numero = new Numero();
            SalidaRespuesta.Text = numero.BinarioDecimal(SalidaRespuesta.Text);
        }

        private void ConvertBinario_Click(object sender, EventArgs e)
        {
            Numero numero;
            numero = new Numero();
            string resultado = "";
            resultado = numero.DecimalBinario(SalidaRespuesta.Text);
            SalidaRespuesta.Text = resultado;
        }     
    }
}
