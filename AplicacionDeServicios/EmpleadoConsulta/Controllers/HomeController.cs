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
            ServicioDeConsulta.ServicioConsultaClient cliente = new ServicioDeConsulta.ServicioConsultaClient();
            List<AplicacionDeServicios.Empleado> empleados = new List<AplicacionDeServicios.Empleado>();
            empleados = cliente.Todos().ToList();

            ViewBag.lista = empleados;

            return View("Index");
        }

        [HttpPost]
        public ActionResult BuscarNombre()
        {
            string a = Request["name"];
            ServicioDeConsulta.ServicioConsultaClient cliente = new ServicioDeConsulta.ServicioConsultaClient();
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

            ServicioDeConsulta.ServicioConsultaClient cliente = new ServicioDeConsulta.ServicioConsultaClient();

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

            ServicioDeConsulta.ServicioConsultaClient cliente = new ServicioDeConsulta.ServicioConsultaClient();
            List<AplicacionDeServicios.Empleado> empleados = new List<AplicacionDeServicios.Empleado>();
            
            /*
            bool isNumero = int.TryParse(Request["legajo"], out int a);

            if (isNumero)
            {
                empleado = cliente.BuscarPorLegajo(int.Parse(Request["legajo"]));
            }
            */

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

            ServicioDeConsulta.ServicioConsultaClient cliente = new ServicioDeConsulta.ServicioConsultaClient();
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


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
