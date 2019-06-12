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
            Alumno alumno = new Alumno(5, "Carlos", "Gonzalez", "12236456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Assert.IsNotNull(alumno.Apellido);
            Assert.IsNotNull(alumno.Nombre);
            Assert.IsNotNull(alumno.Nacionalidad);
            Assert.IsNotNull(alumno.DNI);
        }
        [TestMethod]
        public void pruebaAlumnoRepetido()
        {
            Universidad universidad = new Universidad();
            Alumno Alumno1 = new Alumno(5, "Carlos", "Gonzalez", "12236456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Alumno Alumno2 = new Alumno(5, "Carlos", "Gonzalez", "12236456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);

            universidad += Alumno1;
            try
            {
                universidad += Alumno2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
    }
}
