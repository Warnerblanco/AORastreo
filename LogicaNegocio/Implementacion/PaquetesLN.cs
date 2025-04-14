using AccesoDatos;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion
{
    public class PaquetesLN : IPaquetesLN
    {
        private static AOEntities contexto = new AOEntities();
        private readonly IPaquetesAD _objPaquete = new PaquetesAD(contexto);

        public List<buscarPaquetes_Result> buscarpaquetes()
        {
            List<buscarPaquetes_Result> LobjRespuesta = new List<buscarPaquetes_Result>();
            try
            {
                LobjRespuesta = _objPaquete.buscarpaquetes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LobjRespuesta;
        }
        public List<PA_recPaquetes_Result> recpaquetes()
        {
            List<PA_recPaquetes_Result> LobjRespuesta = new List<PA_recPaquetes_Result>();
            try
            {
                LobjRespuesta = _objPaquete.recpaquetes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LobjRespuesta;
        }
        public PA_recPaquetesXId_Result recPaquetesXID(int pId)
        {
            PA_recPaquetesXId_Result objRespuesta = null;
            try
            {
                var resultList = _objPaquete.recPaquetesXID(pId);
                if (resultList != null && resultList.Count > 0)
                {
                    objRespuesta = resultList.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        public bool insPaquete(paquete pobjPaquete)
        {
            bool LobjRespuesta = false;
            try
            {
                LobjRespuesta = _objPaquete.insPaquete(pobjPaquete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LobjRespuesta;
        }
        public bool delPaquete(int pId)
        {
            bool LobjRespuesta = new bool();
            try
            {
                LobjRespuesta = _objPaquete.delPaquete(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LobjRespuesta;
        }
        public bool updPaquete(paquete pobjPaquete)
        {
            bool LobjRespuesta = new bool();
            try
            {
                LobjRespuesta = _objPaquete.updPaquete(pobjPaquete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LobjRespuesta;
        }
    }
}
