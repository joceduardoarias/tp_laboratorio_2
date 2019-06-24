using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Paquetes paquetes = new Paquetes("d", "7");
            Console.WriteLine(paquetes.MostrarDatos(paquetes));
            Console.ReadKey();
        }
    }
}
