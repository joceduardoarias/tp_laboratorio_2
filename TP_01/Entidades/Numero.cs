using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private Double _numero;


        private string SetNumero
        {
            set { _numero = ValidarNumero(value); }
        }
       
        public Numero() : this(0)
        {

        }
        public Numero(string numero) : this(Double.Parse(numero))
        {

        }
        public Numero(Double numero)
        {
            this._numero = numero;
        }
        
        private Double ValidarNumero(string strNumero)
        {
            Double retorno;
            if (Double.TryParse(strNumero, out retorno))
            {
                retorno = double.Parse(strNumero);
            }
            else
            {
                retorno = 0;
            }
            return retorno;
        }
       
        public string DecimalBinario(Double numero)
        {
            string binario = numero.ToString();
            binario = DecimalBinario(binario);
            return binario;

        }
        
        public string DecimalBinario(string binario)
        {
            int numero;
            string retorno = "";

            if (int.TryParse(binario, out numero))
            {
                while (numero > 0)
                {
                    retorno = (numero % 2).ToString() + retorno;
                    numero = numero / 2;
                }
            }
            else
                retorno = "valor invalido";

            return retorno;
        }
        
        public string BinarioDecimal(string binario)
        {
            int n = 0;
            string retorno = "";
            bool flag = true;
            for (int i = binario.Length - 1, y = 0; i >= 0; i--, y++)
            {
                if (binario[i] == '0' || binario[i] == '1')
                    n += (int)(int.Parse(binario[i].ToString()) * Math.Pow(2, y));
                else
                {
                    retorno = "Valor invalidao";
                    flag = false;
                }
            }
            if(flag == true)
            {
                retorno = n.ToString();
            }
            return retorno;
        }

        public static Double operator -(Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }
        public static Double operator +(Numero n1, Numero n2)
        {
            return n1._numero + n2._numero;
        }
        public static Double operator /(Numero n1, Numero n2)
        {
            return n1._numero / n2._numero;
        }
        public static Double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }

    }
}
