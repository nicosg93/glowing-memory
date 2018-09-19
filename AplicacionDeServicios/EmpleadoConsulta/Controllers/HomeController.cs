using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpleadoConsulta.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MostrarTodo()
        {
            ConsultaEmpleado.ServicioConsultaClient cliente = new ConsultaEmpleado.ServicioConsultaClient();
            List<AplicacionDeServicios.DTO.EmpleadoDTO> empleados = new List<AplicacionDeServicios.DTO.EmpleadoDTO>();
            empleados = cliente.Todos().Empleados;

            ViewBag.lista = empleados;

            return View("Index");
        }

        [HttpPost]
        public ActionResult Buscar()
        {
            string a = Request["name"];

            ConsultaEmpleado.ServicioConsultaClient cliente = new ConsultaEmpleado.ServicioConsultaClient();
            List<AplicacionDeServicios.DTO.EmpleadoDTO> empleados = new List<AplicacionDeServicios.DTO.EmpleadoDTO>();
            empleados = cliente.Buscar(a).Empleados;

            ViewBag.lista = empleados;

            return View("Index");
        }

        /*

        [HttpPost]
        public ActionResult BuscarNombre()
        {
            string a = Request["name"];
            ConsultaEmpleado.ServicioConsultaClient cliente = new ConsultaEmpleado.ServicioConsultaClient();
            List<AplicacionDeServicios.Empleado> empleados = new List<AplicacionDeServicios.Empleado>();

            empleados = cliente.BuscarPorNombre(Request["name"]).ToList();

            ViewBag.lista = empleados;
            if (empleados.Count == 0)
            {
                ViewBag.lista = null;
                ViewBag.Error = "No se encontro en la base de datos";
            }

            return View("Index");
        }
        [HttpPost]
        public ActionResult BuscarApellido()
        {

            ConsultaEmpleado.ServicioConsultaClient cliente = new ConsultaEmpleado.ServicioConsultaClient();

            List<AplicacionDeServicios.Empleado> empleados = new List<AplicacionDeServicios.Empleado>();

            empleados = cliente.BuscarPorApellido(Request["Apellido"]).ToList();

            ViewBag.lista = empleados;
            if (empleados.Count == 0)
            {
                ViewBag.lista = null;
                ViewBag.Error = "No se encontro en la base de datos";
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult BuscarLegajo()
        {

            ConsultaEmpleado.ServicioConsultaClient cliente = new ConsultaEmpleado.ServicioConsultaClient();
            List<AplicacionDeServicios.Empleado> empleados = new List<AplicacionDeServicios.Empleado>();
            
            /*
            bool isNumero = int.TryParse(Request["legajo"], out int a);

            if (isNumero)
            {
                empleado = cliente.BuscarPorLegajo(int.Parse(Request["legajo"]));
            }
            

            empleados= cliente.BuscarPorLegajo(Request["legajo"]).ToList();

            ViewBag.lista = empleados;

            if (empleados.Count == 0)
            {
                ViewBag.lista = null;
                ViewBag.Error = "No se encontro en la base de datos";
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult BuscarDNI()
        {

            ConsultaEmpleado.ServicioConsultaClient cliente = new ConsultaEmpleado.ServicioConsultaClient();
            List<AplicacionDeServicios.Empleado> empleados = new List<AplicacionDeServicios.Empleado>();

            empleados = cliente.BuscarPorDNI(Request["dni"]).ToList();

            ViewBag.lista = empleados;

            if (empleados.Count == 0)
            {
                ViewBag.lista = null;
                ViewBag.Error = "No se encontro en la base de datos";
            }

            return View("Index");
        }
        */
    }
}
