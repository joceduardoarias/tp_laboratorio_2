using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {  
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
       
        public static double Operar(Numero n1, Numero n2, string operador)
        {
            double retorno = 0;

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
                    if (double.IsInfinity(retorno))
                    {
                        retorno = double.MinValue;
                    }
                    break;
                default:
                    break;
            }
            return retorno;
        }

    }
}
