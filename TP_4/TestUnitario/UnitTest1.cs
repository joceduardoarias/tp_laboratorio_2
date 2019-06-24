using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void ListaCorreoInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }
        [TestMethod]
        [ExpectedException(typeof(TrackinIdrepetidoException))]
        public void TrackingIDRepetido()
        {
            Correo correo = new Correo();
            Paquetes p1 = new Paquetes("Mitre 123", "444");
            Paquetes p2 = new Paquetes("Alsina 987", "444");
            correo += p1;
            correo += p2;
        }
    }
}
