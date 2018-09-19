using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AplicacionDeServicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioConsulta" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioConsulta.svc o ServicioConsulta.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioConsulta : IServicioConsulta
    {
        //private ProyectoEntities db = new ProyectoEntities();

        public Response.ResponseEmpleado Buscar(string palabra)
        {
            var response = new Response.ResponseEmpleado();
            try
            {
                using (var context = new Model.Model1())
                {
                    var data = context.Empleado.Where
                        (empleado => empleado.Apellido.Contains(palabra)||
                            empleado.DNI.ToString().Contains(palabra)||
                            empleado.Nombre.Contains(palabra)).
                            ToList();

                    if (data == null)
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "No hay datos";

                        return response;
                    }
                    foreach (Model.Empleado empleado in data)
                    {
                        DTO.EmpleadoDTO empleadoDTO = new DTO.EmpleadoDTO();
                        empleadoDTO.Apellido = empleado.Apellido;
                        empleadoDTO.DNI = empleado.DNI.ToString();
                        empleadoDTO.Legajo = empleado.Legajo.ToString();
                        empleadoDTO.Nombre = empleado.Nombre;
                        empleadoDTO.Telefono = empleado.Telefono.ToString();

                        /*
                        response.Empleados[posicion].Apellido = empleado.Apellido;
                        response.Empleados[posicion].DNI = empleado.DNI.ToString();
                        response.Empleados[posicion].EmpleadoId = empleado.EmpleadoId.ToString();
                        response.Empleados[posicion].Legajo = empleado.Legajo.ToString();
                        response.Empleados[posicion].Nombre = empleado.Nombre;
                        response.Empleados[posicion].Telefono = empleado.Telefono.ToString();
                        */
                        response.Empleados.Add(empleadoDTO);
                    }

                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;

                return response;
            }

            return response;
        }
        /*
    
        public Response.ResponseEmpleado BuscarPorId(string id)
        {
            Response.ResponseEmpleado response = new Response.ResponseEmpleado();
            try
            {
                using (var context = new Model.Model1())
                {
                    var data = context.Empleado.Single(empleado => empleado.EmpleadoId.ToString() == id);

                    if (data == null)
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "No hay datos";

                        return response;
                    }

                    response.Empleados.First().Apellido = data.Apellido;
                    response.Empleados.First().DNI = data.DNI;
                    response.Empleados.First().EmpleadoId = data.EmpleadoId.ToString();
                    response.Empleados.First().Legajo = data.Legajo.ToString();
                    response.Empleados.First().Nombre = data.Nombre;
                    response.Empleados.First().Telefono = data.Telefono.ToString();

                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;

                return response;
            }

            return response;
        }


        public List<Empleado> BuscarPorNombre(string nombre)
        {
            return db.Empleado.Where(empleado => empleado.Nombre.ToUpper().Contains(nombre.ToUpper())).ToList();
        }

        public List<Empleado> BuscarPorLegajo(string legajo)
        {
            try
            {

                return db.Empleado.Where(empleado => empleado.Legajo.ToString().Contains(legajo)).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Empleado> BuscarPorDNI(string d)
        {
            try
            {
                string dni = d.Replace(".", "");

                return db.Empleado.Where(empleado => empleado.DNI.Replace(".","").Contains(dni)).ToList();
            }
            catch (Exception)
            {

                return null;
            }
           
        }

        public List<Empleado> BuscarPorApellido(string apellido)
        {
            return db.Empleado.Where(empleado => empleado.Apellido.Contains(apellido)).ToList();
        }
        */

        public Response.ResponseEmpleado Todos()
        {
            Response.ResponseEmpleado response = new Response.ResponseEmpleado();
            try
            {
                using (var context = new Model.Model1())
                {
                    var data = context.Empleado.ToList();

                    if (data.Count() == 0)
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "No hay datos";

                        return response;
                    }
                    foreach (Model.Empleado empleado in data)
                    {
                        DTO.EmpleadoDTO empleadoDTO = new DTO.EmpleadoDTO();
                        empleadoDTO.Apellido = empleado.Apellido;
                        empleadoDTO.DNI = empleado.DNI.ToString();
                        empleadoDTO.Legajo = empleado.Legajo.ToString();
                        empleadoDTO.Nombre = empleado.Nombre;
                        empleadoDTO.Telefono = empleado.Telefono.ToString();

                        response.Empleados.Add(empleadoDTO);
                    }

                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;

                return response;
            }

            return response;
        }

    }
}
