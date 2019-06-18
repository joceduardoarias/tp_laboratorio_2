using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Paquetes paquetes = new Paquetes("gurruchaga25225", "1");
            PaqueteDAO.Insertar(paquetes);

        }
    }
}
