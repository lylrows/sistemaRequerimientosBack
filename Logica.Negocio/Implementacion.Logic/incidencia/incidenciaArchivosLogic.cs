using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.incidencia
{
    public class incidenciaArchivosLogic : IIncidenciaArchivosLogic
    {
        private IUnitOfWork _unitOfWork;

        public incidenciaArchivosLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_incidenciaArchivos GetById(int id)
        {
            return _unitOfWork.IIncidenciaArchivos.GetById(id);
        }

        public IEnumerable<t_incidenciaArchivos> GetList()
        {
            return _unitOfWork.IIncidenciaArchivos.GetList();
        }

        public int Insert(t_incidenciaArchivos obj)
        {
            return _unitOfWork.IIncidenciaArchivos.Insert(obj);
        }

        public bool Update(t_incidenciaArchivos obj)
        {
            return _unitOfWork.IIncidenciaArchivos.Update(obj);
        }

        public List<incidenciaArchivos_complete> getArchivosByIncidencia(int id)
        {
            return _unitOfWork.IIncidenciaArchivos.getArchivosByIncidencia(id);
        }
    }
}
