using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class TrackinIdrepetidoException:Exception
    {
        public TrackinIdrepetidoException(string mensaje):base(mensaje)
        {

        }
        public TrackinIdrepetidoException(string mensaje,Exception inner):base(mensaje,inner)
        {
           
        }
    }
}
