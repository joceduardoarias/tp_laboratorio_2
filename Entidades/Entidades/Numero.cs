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
        //CONSTRUCOR
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
        /// <summary>
        /// Valida que el valor ingresado por el usuario sea un numerico, si es true,
        /// retorna el valor ingresado, de los contrario retornara 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>retrono</returns>
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
        /// <summary>
        ///  Convierte un numero decimal en binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>binario</returns>
        public string DecimalBinario(Double numero)
        {
            string binario = "";



            while (numero > 0)
            {
                if (numero % 2 == 0)
                {
                    binario = "0" + binario;
                }
                else
                {
                    binario = "1" + binario;
                }
                numero = (numero / 2);
            }

            if (numero == 0)
            {
                binario = "0";
            }
            else
            {
                binario = "Valor invalido";
            }
            return binario;

        }
        /// <summary>
        /// Convierte un numero decimal en binario
        /// </summary>
        /// <param name="numero">valor de entrada</param>
        /// <returns>binario</returns>
        public string DecimalBinario(string numero)
        {
            string binario = "Valor invalido";
            int aux;
            // bool flag = int.TryParse(numero, out aux);
            if (int.TryParse(numero, out aux))
            {
                while (aux > 0)
                {
                    if (aux % 2 == 0)
                    {
                        binario = "0" + binario;
                    }
                    else
                    {
                        binario = "1" + binario;
                    }
                    numero = (aux / 2).ToString();
                }
            }
            else if (numero == "0")
            {
                binario = "0";
            }
            else
            {
                binario = "Valor invalido";
            }
            return binario;
        }
        /// <summary>
        /// Método que convierte un binario ASCII en un número entero
        /// </summary>
        /// <param name="binario">Binario ASCII a convertir. EJ: 1001</param>
        /// <returns>Valor entero resultado de la conversión. EJ: 9</returns>
        public string BinarioEntero(string binario)
        {
            int exponente = 0, residuo = 0, resultado = 0;
            int numero;

            if (int.TryParse(binario, out numero))
            {

                do
                {
                    residuo = numero % 10;
                    numero = numero / 10;
                    resultado += (int)(residuo * Math.Pow(2, exponente));
                    exponente++;
                } while (numero != 0);
            }
            else
            {
                return "Valor invalido";
            }

            return resultado.ToString();
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
