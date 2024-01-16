using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;

namespace Logica.Negocio.Interfaces.Logic.configuracion
{
    public interface IModificarActivoLogic
    {
        modificacionActivoDTO ModificarActivo(string tabla, int valor, int id);
    }
}
