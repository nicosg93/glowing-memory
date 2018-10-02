using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AplicacionDeServicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioConsulta" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioConsulta
    {
        /*
        [OperationContract]
        Response.ResponseEmpleado BuscarPorId(string id);

        [OperationContract]
        List<Empleado> BuscarPorNombre(string nombre);

        [OperationContract]
        List<Empleado> BuscarPorLegajo(string legajo);

        [OperationContract]
        List<Empleado> BuscarPorDNI(string DNI);

        [OperationContract]
        List<Empleado> BuscarPorApellido(string apellido);

        */
        [OperationContract]
        Response.ResponseEmpleado Todos();

        [OperationContract]
        Response.ResponseEmpleado Buscar(string palabra);

        [OperationContract]
        bool Eliminar(string id);

        [OperationContract]
        bool Editar(DTO.EmpleadoDTO empleado);
    }
}
