using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleadoConsulta.Models
{
    public class EmpleadoModel
    {
        public string EmpleadoId { get; set; }

        public string Legajo { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DNI { get; set; }

        public string Telefono { get; set; }

        public EmpleadoModel(string empleadoId, string legajo, string nombre, string apellido, string dNI, string telefono)
        {
            EmpleadoId = empleadoId;
            Legajo = legajo;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dNI;
            Telefono = telefono;
        }

        public EmpleadoModel() { }
    }
}