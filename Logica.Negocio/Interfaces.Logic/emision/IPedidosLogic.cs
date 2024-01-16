using Modelos.Datos.Mapeo.Base.Datos.correo;
using Modelos.Datos.Mapeo.Base.Datos.emision;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Solicitud.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Negocio.Interfaces.Logic.emision
{
    public interface IPedidosLogic
    {
        bool Update(pedidos obj);
        int Insert(pedidos obj);
        IEnumerable<pedidos> GetList();
        pedidos GetById(int id);
        bool Delete(pedidos obj);
        void insertArchivos(pedidosArchivos archivos);
        List<emissionOrdersGrid> getEmissionOrdersGrid();
        ResultadoEnvio envioCorreoPedido(int idPedido, pedidos obj, List<string> adjuntos, string ruta);
        List<asignarPedido> getPboUsers(int id);
        bool asignarPedido(int idUsuario, int id);
        bool aprobacionCorreo(aprobacionCorreoDTO obj);
        bool respuestaEmision(aprobacionCorreoDTO obj);
    }
}
