using Logica.Negocio.Interfaces.Logic.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Solicitud.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.incidencia
{
    public class tagsIncidenciasLogic : ITagsincidenciasLogic
    {
        private IUnitOfWork _unitOfWork;

        public tagsIncidenciasLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public tagsIncidencias GetById(int id)
        {
            return _unitOfWork.ITagsincidencias.GetById(id);
        }

        public IEnumerable<tagsIncidencias> GetList()
        {
            return _unitOfWork.ITagsincidencias.GetList();
        }

        public int Insert(tagsIncidencias obj)
        {
            return _unitOfWork.ITagsincidencias.Insert(obj);
        }

        public bool Update(tagsIncidencias obj)
        {
            return _unitOfWork.ITagsincidencias.Update(obj);
        }

        public bool Delete(tagsIncidencias obj)
        {
            return _unitOfWork.ITagsincidencias.Delete(obj);
        }

        public IEnumerable<tags> getTagListByIdIncidencia(int id)
        {
            return _unitOfWork.ITagsincidencias.getTagListByIdIncidencia(id);
        }

        public IEnumerable<tagsIncidenciaDTO> getTagsByIncidencias(filterDataMejorasDTO obj)
        {
            return _unitOfWork.ITagsincidencias.getTagsByIncidencias(obj);
        }
    }
}
