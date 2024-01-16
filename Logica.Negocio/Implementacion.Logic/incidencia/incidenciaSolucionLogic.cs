using System;
using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Modelos.Datos.Solicitud.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.incidencia
{
    public class incidenciaSolucionLogic:IIncidenciaSolucionLogic
    {
        private IUnitOfWork _unitOfWork;
        private IIncidenciaSolucionArchivosLogic _incidenciaSolArchivosLogic;
        private IIncidenciaSolucionPalabrasClaveLogic _incidenciaSolPalabrasLogic;

        public incidenciaSolucionLogic(IUnitOfWork unitOfWork,IIncidenciaSolucionPalabrasClaveLogic incidenciaSolPalabrasLogic, IIncidenciaSolucionArchivosLogic incidenciaSolArchivosLogic)
        {
            _unitOfWork = unitOfWork;
            _incidenciaSolArchivosLogic = incidenciaSolArchivosLogic;
            _incidenciaSolPalabrasLogic = incidenciaSolPalabrasLogic;
        }

        public incidenciaSolArchivosPalabras GetById(int id)
        {
            incidenciaSolArchivosPalabras data = new incidenciaSolArchivosPalabras();
            data.incidenciaSol= _unitOfWork.IIncidenciaSolucion.GetById(id);
            data.lstIncidenciaSolPalabras = _unitOfWork.IIncidenciaSolucionPalabrasClave.GetByIdIncSol(id);
            data.lstIncidenciaSolArchivos = _unitOfWork.IIncidenciaSolucionArchivos.GetByIdIncSol(id);
            return data;
        }

        public int Insert(t_incidenciaSolucion obj)
        {
            return _unitOfWork.IIncidenciaSolucion.Insert(obj);
        }

        public IEnumerable<t_incidenciaSolucion> GetList()
        {
            return _unitOfWork.IIncidenciaSolucion.GetList();
        }

        public int Insert(incidenciaSolArchivosPalabras obj)
        {
            try
            {
                int id_incidenciaSol = _unitOfWork.IIncidenciaSolucion.Insert(obj.incidenciaSol);
                for (int i = 0; i < obj.lstIncidenciaSolArchivos.Count; i++)
                {
                    obj.lstIncidenciaSolArchivos[i].idIncidenciaSolucion = id_incidenciaSol;
                    _incidenciaSolArchivosLogic.Insert(obj.lstIncidenciaSolArchivos[i]);
                }
                for (int i = 0; i < obj.lstIncidenciaSolPalabras.Count; i++)
                {
                    obj.lstIncidenciaSolPalabras[i].idIncidenciaSolucion = id_incidenciaSol;
                    _incidenciaSolPalabrasLogic.Insert(obj.lstIncidenciaSolPalabras[i]);
                }
                return 1;

            }
            catch(Exception e) { return 0; }
        }

        public bool Update(t_incidenciaSolucion obj)
        {
            return _unitOfWork.IIncidenciaSolucion.Update(obj);
        }
        public List<incidenciaSolucion_complete> getIncidenciaSolucionesFilter(int id)
        {
            return _unitOfWork.IIncidenciaSolucion.getIncidenciaSolucionesFilter(id);
        }
        public List<incidenciaSolTagFilterResponse> getIncidenciasSolucionesByTagFilter(List<palabrasClave_tag> req)
        {
            return _unitOfWork.IIncidenciaSolucion.getIncidenciasSolucionesByTagFilter(req);
        }

        public solucionDTO getSolutionById(int id)
        {
            
            return _unitOfWork.IIncidenciaSolucion.getSolutionById(id);
        }

        public List<solutionImgDTO> getSolutionImg(int id)
        {
            return _unitOfWork.IIncidenciaSolucion.getSolutionImg(id);
        }
    }
}
