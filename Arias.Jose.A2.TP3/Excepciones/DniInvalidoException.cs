using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
   public class DniInvalidoException: Exception
    {
        private string mensajeBase;

        #region CONSTRUCTOR
        public DniInvalidoException()
        {

        }
        public DniInvalidoException(Exception e):base("",e)
        {

        }
        public DniInvalidoException(string message):base(message,null)
        {
            this.mensajeBase = message;
        }
        public DniInvalidoException(string message, Exception e):base(message,e)
        {
            this.mensajeBase = message;
        }
        #endregion
    }
}
