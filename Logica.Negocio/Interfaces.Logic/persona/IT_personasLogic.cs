using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;

namespace Logica.Negocio.Interfaces.Logic.persona
{
    public interface IT_personasLogic
    {
        bool Update(personas obj);
        int Insert(personas obj);
        IEnumerable<personas> GetList();
        personas GetById(int id);
        bool Delete(personas obj);
        getNombresDTO GetNombres(int id);
        int InsertUser(personas obj, string contrasenia);
        IEnumerable<personas> getUsuariosByEmpresa(in int id);
        IEnumerable<usuariosByEmpresaDTO> getUsersByIdEmpresa(in int id);
        int InsertIncidenciaArchivo(t_incidenciaArchivos incidenciaArchivo);
    }
}
