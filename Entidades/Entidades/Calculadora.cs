using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {   /// <summary>
        /// Deberá validar que el operador recibido sea +, -, / o *. Caso contrario retornará +.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>eperador binario</returns>
        private static string ValidarOperador(string operador)
        {

            switch (operador)
            {
                case "-":
                    operador = "-";
                    break;
                case "+":
                    operador = "+";
                    break;
                case "*":
                    operador = "*";
                    break;
                case "/":
                    operador = "/";
                    break;
                default:
                    operador = "+";
                    break;
            }
            return operador;
        }
        /// <summary>
        /// Validará y realizará la operación pedida entre ambos números.
        /// Si se tratara de una división por 0, retornará double.MinValue.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero n1, Numero n2, string operador)
        {
            double retorno = 0;
            string aux = n2.ToString();
            if (aux == "0" && ValidarOperador(operador) == "/")// validar que sea igual a cero y operador "/"
            {
                return Double.MinValue;
            }
            switch (ValidarOperador(operador))
            {
                case "+":
                    retorno = n1 + n2;
                    break;
                case "-":
                    retorno = n1 - n2;
                    break;
                case "*":
                    retorno = n1 * n2;
                    break;
                case "/":
                    retorno = n1 / n2;
                    break;
            }
            return retorno;
        }

    }
}
