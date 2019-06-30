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
        public Persona() 
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad):this()
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
        /// <summary>
        /// Método por defecto, devuelte la info de la persona en una cadena
        /// </summary>
        /// <returns>info de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: "+this.apellido+","+ this.nombre);
            sb.AppendLine("Nacionalidad:"+ this.nacionalidad);
            return sb.ToString();
        }
        /// <summary>
        /// Valida que el número de DNI coincida con la nacionalidad de acuerdo a un criterio
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Devuelve el número de DNI ya validado, caso contrario tira excepción</returns>
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
        /// <summary>
        /// Convierte un DNI pasado como string a int. Valida que esté correctamente escrito.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI de la persona.</param>
        /// <returns>DNI valido ó lanza DniInvalidoException caso contrario.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux = int.Parse(dato);
            return ValidarDni(nacionalidad, aux);
        }
        /// <summary>
        /// Valida que el nombre solo contenga caracteres validos para un nombre
        /// </summary>
        /// <param name="dato">cadena de texto a ser analizada</param>
        /// <returns> nombre verificado o cadena vacia </returns>
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
