using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rastreo.Controllers
{
    public class HomeController : Controller

    {
        private IPaquetesLN objPaquetes = new PaquetesLN();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaPaquetes()
        {
            List<PA_recPaquetes_Result> LstPaquetes = new List<PA_recPaquetes_Result>();
            LstPaquetes = objPaquetes.recpaquetes();
            return View(LstPaquetes);
        }
        public ActionResult BuscarPorId(int id_paquete)
        {
            
            List<PA_recPaquetes_Result> LstPaquetes = objPaquetes.recpaquetes();

            
            var resultado = LstPaquetes.Where(p => p.id_paquete == id_paquete).ToList();

            if (!resultado.Any())
            {
                ViewBag.Mensaje = "Lo sentimos, no tenemos registrado su paquete. Si cree que esto es un error, verifique el número de factura.";
            }

            return View("Index", resultado);
        }

        

    }
}