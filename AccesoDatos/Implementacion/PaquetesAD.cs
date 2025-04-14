using AccesoDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos.Implementacion
{
    public class PaquetesAD : IPaquetesAD
    {
        private AOEntities contexto;
        public PaquetesAD(AOEntities contexto)
        {
            this.contexto = new AOEntities();
        }

        public List<buscarPaquetes_Result> buscarpaquetes()
        {
            List<buscarPaquetes_Result> LobjRespuesta = new List<buscarPaquetes_Result>();
            try
            {
                LobjRespuesta = contexto.buscarPaquetes(null, null, null).ToList();
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
                LobjRespuesta = contexto.PA_recPaquetes().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LobjRespuesta;
        }

        public List<PA_recPaquetesXId_Result> recPaquetesXID(int pId)
        {
            List<PA_recPaquetesXId_Result> LobjRespuesta = new List<PA_recPaquetesXId_Result>();
            try
            {
                LobjRespuesta = contexto.PA_recPaquetesXId(pId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LobjRespuesta;
        }

        public bool insPaquete(paquete pobjPaquete)
        {
            var proxyCreationEnable = contexto.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = contexto.PA_insPaquete(pobjPaquete.numero_factura, pobjPaquete.nombre_apellidos, pobjPaquete.tienda, pobjPaquete.articulo, pobjPaquete.fecha_envio, pobjPaquete.estado);

                if (intVal == 1)
                {
                    objRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                contexto.Configuration.ProxyCreationEnabled = proxyCreationEnable;
            }
            return objRespuesta;
        }

        public bool modPaquete(paquete pobjPaquete)
        {
            var proxyCreationEnable = contexto.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;
                intVal = contexto.PA_modPaquete(pobjPaquete.id_paquete, pobjPaquete.numero_factura, pobjPaquete.nombre_apellidos, pobjPaquete.tienda, pobjPaquete.articulo, pobjPaquete.fecha_envio, pobjPaquete.estado);
                if (intVal == 1)
                {
                    objRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                contexto.Configuration.ProxyCreationEnabled = proxyCreationEnable;
            }
            return objRespuesta;
        }

        public bool delPaquete(int pId)
        {
            var proxyCreationEnable = contexto.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;
                intVal = contexto.PA_delPaquete(pId);
                if (intVal == 1)
                {
                    objRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                contexto.Configuration.ProxyCreationEnabled = proxyCreationEnable;
            }
            return objRespuesta;
        }

        public bool updPaquete(paquete pobjPaquete)
        {
            var proxyCreationEnable = contexto.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();
            try
            {
                objRespuesta = false;
                int intVal = 0;
                intVal = contexto.PA_modPaquete(pobjPaquete.id_paquete, pobjPaquete.numero_factura, pobjPaquete.nombre_apellidos, pobjPaquete.tienda, pobjPaquete.articulo, pobjPaquete.fecha_envio, pobjPaquete.estado);
                if (intVal == 1)
                {
                    objRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                contexto.Configuration.ProxyCreationEnabled = proxyCreationEnable;
            }
            return objRespuesta;
        }
    }
}
