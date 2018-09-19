using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionDeServicios.Response
{
    public class ResponseEmpleado : ResponseBase
    {
        private List<DTO.EmpleadoDTO> empleados;

        public List<DTO.EmpleadoDTO> Empleados
        {
            get { return empleados; }
            set { empleados = value; }
        }


        public ResponseEmpleado()
        {
            empleados = new List<DTO.EmpleadoDTO>();
            IsValid = true;
        }
    }
}