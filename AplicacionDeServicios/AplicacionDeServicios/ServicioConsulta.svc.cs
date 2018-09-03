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
        private ProyectoEntities db = new ProyectoEntities();

        public Empleado BuscarPorId(int id)
        {
            try
            {
                return db.Empleado.Single(empleado => empleado.EmpleadoId == id);
            }
            catch (Exception)
            {

                throw;
            }
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

        public List<Empleado> Todos()
        {
            return db.Empleado.ToList();
        }

    }
}
