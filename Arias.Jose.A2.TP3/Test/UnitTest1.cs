using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Excepciones;
using ClasesInstanciables;
using EntidadesAbstractas;
namespace Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestDniInvalidoException()
        {
            try
            {
                Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92/6*456", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail();
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }
        [TestMethod]
        public void AlumnoArgentinoValido()
        {
            try
            {
                Alumno a = new Alumno(1, "Juan", "Lopez", "12234456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                Assert.AreEqual<string>(a.Nombre, "Juan");
                Assert.AreEqual<string>(a.Apellido, "Lopez");
                Assert.AreEqual<int>(a.DNI, 12234456);
                Assert.AreEqual<Persona.ENacionalidad>(a.Nacionalidad, Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestNacionalidadInvalidaException()
        {
            try
            {
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
                Assert.Fail();
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
        [TestMethod]
        public void TestAtributosAlumnoNotNull()
        {
            Alumno a1 = new Alumno(4, "Miguel", "Hernandez", "92/6*456", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            Assert.IsNotNull(a1.Nacionalidad);
            Assert.IsNotNull(a1.Nombre);
            Assert.IsNotNull(a1.Apellido);
            Assert.IsNotNull(a1.DNI);
        }
        [TestMethod]
        public void AlumnoArgentinoDNIInvalido()
        {
            try
            {
                Alumno a = new Alumno(1, "Juan", "Lopez", "92234456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                Assert.Fail("Alumno argentino con DNI extranjero");
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
            
        }
    }
}
