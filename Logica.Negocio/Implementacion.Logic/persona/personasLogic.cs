using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.persona;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.persona
{
    public class personasLogic : IT_personasLogic
    {
        private IUnitOfWork _unitOfWork;

        public personasLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public personas GetById(int id)
        {
            return _unitOfWork.IT_personas.GetById(id);
        }

        public IEnumerable<personas> GetList()
        {
            return _unitOfWork.IT_personas.GetList();
        }

        public int Insert(personas obj)
        {
            return _unitOfWork.IT_personas.Insert(obj);
        }

        public bool Update(personas obj)
        {
            return _unitOfWork.IT_personas.Update(obj);
        }

        public bool Delete(personas obj)
        {
            return _unitOfWork.IT_personas.Delete(obj);
        }

        public getNombresDTO GetNombres(int id)
        {
            return _unitOfWork.IT_personas.GetNombres(id);
        }

        public int InsertUser(personas obj, string contrasenia)
        {
            return _unitOfWork.IT_personas.InsertUser(obj,contrasenia);
        }

        public IEnumerable<personas> getUsuariosByEmpresa(in int id)
        {
            return _unitOfWork.IT_personas.getUsuariosByEmpresa(id);
        }

        public IEnumerable<usuariosByEmpresaDTO> getUsersByIdEmpresa(in int id)
        {
            return _unitOfWork.IT_personas.getUsersByIdEmpresa(id);
        }

        public int InsertIncidenciaArchivo(t_incidenciaArchivos incidenciaArchivo)
        {
            return _unitOfWork.IIncidenciaArchivos.Insert(incidenciaArchivo);
        }
    }
}
