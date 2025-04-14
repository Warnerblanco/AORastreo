using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IPaquetesAD
    {
        List<buscarPaquetes_Result> buscarpaquetes();
        List<PA_recPaquetes_Result> recpaquetes();
        List<PA_recPaquetesXId_Result> recPaquetesXID(int pId);
        bool insPaquete(paquete pobjPaquete);
        bool delPaquete(int pId);
        bool updPaquete(paquete pobjPaquete);
    }
}
