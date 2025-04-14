using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicaNegocio.Implementacion;
using Entidades;    

namespace Rastreo.Controllers
{
    public class PaquetesController : Controller
    {
        private IPaquetesLN objPaquetes = new PaquetesLN();

        public ActionResult ListaPaquetes()
        {
            List<PA_recPaquetes_Result> LstPaquetes = new List<PA_recPaquetes_Result>();
            LstPaquetes = objPaquetes.recpaquetes();
            return View(LstPaquetes);
        }

        public ActionResult CrearPaquetes()
        {
            return View();
        }

        public ActionResult modificarunPaquete(int id_cliente)
        {
            PA_recPaquetesXId_Result ObjPaquete = new PA_recPaquetesXId_Result();
            paquete objPaqueteEnt = new paquete();
            ObjPaquete = objPaquetes.recPaquetesXID(id_cliente);
            objPaqueteEnt.id_paquete = ObjPaquete.id_paquete;
            objPaqueteEnt.numero_factura = ObjPaquete.numero_factura;
            objPaqueteEnt.nombre_apellidos = ObjPaquete.nombre_apellidos;
            objPaqueteEnt.tienda = ObjPaquete.tienda;
            objPaqueteEnt.articulo = ObjPaquete.articulo;
            objPaqueteEnt.fecha_envio = ObjPaquete.fecha_envio;
            objPaqueteEnt.estado = ObjPaquete.estado;
            return View(objPaqueteEnt);
        }
        public ActionResult EliminarunPaquete(int id)
        {
            PA_recPaquetesXId_Result ObjPaquete = new PA_recPaquetesXId_Result();
            paquete objPaqueteEnt = new paquete();
            ObjPaquete = objPaquetes.recPaquetesXID(id);
            objPaqueteEnt.id_paquete = ObjPaquete.id_paquete;
            objPaqueteEnt.numero_factura = ObjPaquete.numero_factura;
            objPaqueteEnt.nombre_apellidos = ObjPaquete.nombre_apellidos;
            objPaqueteEnt.tienda = ObjPaquete.tienda;
            objPaqueteEnt.articulo = ObjPaquete.articulo;
            objPaqueteEnt.fecha_envio = ObjPaquete.fecha_envio;
            objPaqueteEnt.estado = ObjPaquete.estado;
            return View(objPaqueteEnt);

        }
        //metodos 
       

        //Metodos

        public ActionResult IngresarPaquete(paquete objPaquete)
        {
            List<PA_recPaquetes_Result> lstPaquetes = new List<PA_recPaquetes_Result>();
            try
            {
                if (objPaquetes.insPaquete(objPaquete))
                {
                    lstPaquetes = objPaquetes.recpaquetes();
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaPaquetes", lstPaquetes);
        }

        public ActionResult ModificarPaquete(paquete objPaquete)
        {
            List<PA_recPaquetes_Result> lstPaquetes = new List<PA_recPaquetes_Result>();
            try
            {
                if (objPaquetes.updPaquete(objPaquete))
                {
                    lstPaquetes = objPaquetes.recpaquetes();
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaPaquetes", lstPaquetes);
        }
        public ContentResult FiltroPaquetesAjax(string filtro)
        {
            var resultados = objPaquetes.recpaquetes();

            if (!string.IsNullOrEmpty(filtro))
            {
                resultados = resultados.Where(p =>
                    (p.nombre_apellidos != null && p.nombre_apellidos.Contains(filtro)) ||
                    (p.tienda != null && p.tienda.Contains(filtro)) ||
                    p.numero_factura.ToString().Contains(filtro)).ToList();
            }

            
            string filas = string.Join("", resultados.Select(p => $@"
        <tr>
            <td>{p.id_paquete}</td>
            <td>{p.numero_factura}</td>
            <td>{p.nombre_apellidos}</td>
            <td>{p.tienda}</td>
            <td>{p.articulo}</td>
            <td>{p.fecha_envio:yyyy-MM-dd}</td>
            <td>{p.estado}</td>
            <td><a href='/Paquetes/ModificarPaquete?id={p.id_paquete}'>Modificar</a></td>
        </tr>"));

            return Content(filas, "text/html");
        }


        [HttpPost]
        public ActionResult Acciones(string submitButton, paquete pPaquete)
        {
            try
            {
                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarPaquete(pPaquete);

                    case "Actualizar":
                        return ModificarPaquete(pPaquete);
                    

                    default:
                        return RedirectToAction("ListaPaquetes", "Paquetes");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Paquete", "Acciones"));
            }
        }
    }   
}