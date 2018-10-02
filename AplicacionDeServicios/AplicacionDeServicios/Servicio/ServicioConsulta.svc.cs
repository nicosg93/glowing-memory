using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public bool Eliminar(string id)
        {
            try
            {
                using (var context = new Model.Model1())
                {

                    Model.Empleado empleadoAEliminar = context.Empleado.Find(int.Parse(id));

                    context.Empleado.Remove(empleadoAEliminar);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Editar( DTO.EmpleadoDTO empleado)
        {
            try
            {
                using (var context = new Model.Model1())
                {

                    Model.Empleado empleadoAEditar = new Model.Empleado();
                    empleadoAEditar.EmpleadoId = int.Parse(empleado.EmpleadoId);
                    empleadoAEditar.Apellido = empleado.Apellido;
                    empleadoAEditar.DNI = empleado.DNI;
                    empleadoAEditar.Legajo = int.Parse(empleado.Legajo);
                    empleadoAEditar.Nombre = empleado.Nombre;
                    empleadoAEditar.Telefono = empleadoAEditar.Telefono;

                    context.Entry(empleadoAEditar).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public Response.ResponseEmpleado Buscar(string palabra)
        {
            var response = new Response.ResponseEmpleado();
            try
            {
                using (var context = new Model.Model1())
                {

                    //Aplicando uso de linQ
                    
                        var resultado = from e in context.Empleado
                                       where e.Apellido.Contains(palabra) ||
                                       e.DNI.ToString().Contains(palabra) ||
                                       e.Nombre.Contains(palabra)
                                       select e;

                        
                    List<DTO.EmpleadoDTO> data = resultado.ToList().ConvertAll( e => new DTO.EmpleadoDTO(
                            e.EmpleadoId.ToString(),
                            e.Legajo.ToString(),
                            e.Nombre, e.Apellido,
                            e.DNI,
                            e.Telefono));

                    /* Aplicacion sin uso de linQ
                     var data = context.Empleado.Where
                            (empleado => empleado.Apellido.Contains(palabra)||
                            empleado.DNI.ToString().Contains(palabra)||
                            empleado.Nombre.Contains(palabra)).
                            ToList();
                            */
                    if (data == null)
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "No hay datos";

                        return response;
                    }
                    foreach (DTO.EmpleadoDTO empleado in data)
                    {
                        response.Empleados.Add(empleado);
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
                using (Model.Model1 context = new Model.Model1())
                {
                    List<DTO.EmpleadoDTO> data = context.Empleado.ToList().ConvertAll(
                        e => new DTO.EmpleadoDTO(
                            e.EmpleadoId.ToString(),
                            e.Legajo.ToString(),
                            e.Nombre,e.Apellido,
                            e.DNI,
                            e.Telefono));

                    //Aplicando uso de linQ
                    /* var data = from e in context.Empleado
                               select e;
                    */
                    //Sin uso de linQ --------> var data = context.Empleado.ToList();

                    if (data.Count() == 0)
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "No hay datos";

                        return response;
                    }

                    foreach (DTO.EmpleadoDTO empleado in data)
                    {
                        response.Empleados.Add(empleado);
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
