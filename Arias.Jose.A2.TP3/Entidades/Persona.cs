using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;
namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #region Campos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {

            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructor
        public Persona() : this("", "", ENacionalidad.Argentino)
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metdos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: "+this.apellido+","+ this.nombre);
            //sb.AppendLine("DNI:"+ this.dni);
            sb.AppendLine("Nacionalidad:"+ this.nacionalidad);
            return sb.ToString();
        }
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Extranjero:
                    {
                        if (dato > 89999999 && dato < 99999999)
                        {
                            return dato;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("Nacionalidad Invalida");
                        }
                    }

                case ENacionalidad.Argentino:
                    {
                        if (dato > 0 && dato <= 89999999)
                        {
                            return dato;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("nacionalidad invalida");
                        }
                    }
            }
            throw new DniInvalidoException();
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux = int.Parse(dato);
            return ValidarDni(nacionalidad, aux);
        }
        private string ValidarNombreApellido(string datos)
        {
            if (Regex.IsMatch(datos, @"^[a-zA-Z]+$"))
            {
                return datos;
            }
            return "";
        }

        #endregion

    }
}
