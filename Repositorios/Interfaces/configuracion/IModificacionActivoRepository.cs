using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;


namespace Repositorios.Interfaces.configuracion
{
    public interface IModificacionActivoRepository:IRepository<modificacionActivoDTO>
    {
        modificacionActivoDTO ModificarActivo(string tabla, int valor,int id);
    }
}
