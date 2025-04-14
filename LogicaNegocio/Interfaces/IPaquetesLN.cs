using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IPaquetesLN
    {
        List<buscarPaquetes_Result> buscarpaquetes();
        List<PA_recPaquetes_Result> recpaquetes();
        PA_recPaquetesXId_Result recPaquetesXID(int pId);
        bool insPaquete(paquete pobjPaquete);
        bool delPaquete(int pId);
        bool updPaquete(paquete pobjPaquete);
    }
}
