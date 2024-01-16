using System;
using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Solicitud.DTO;
using Unidad.Trabajo;


namespace Logica.Negocio.Implementacion.Logic.incidencia
{
    public class incidenciaSolucionPalabrasClaveLogic:IIncidenciaSolucionPalabrasClaveLogic
    {
        private IUnitOfWork _unitOfWork;
        private IParametroDetalles _parametroDetalles;

        public incidenciaSolucionPalabrasClaveLogic(IUnitOfWork unitOfWork, IParametroDetalles parametroDetalles)
        {
            _unitOfWork = unitOfWork;
            _parametroDetalles = parametroDetalles;
        }

        public t_incidenciaSolucionPalabrasClave GetById(int id)
        {
            return _unitOfWork.IIncidenciaSolucionPalabrasClave.GetById(id);
        }

        public List<t_incidenciaSolucionPalabrasClave> GetByIdIncSol(int id_incSol)
        {
            return _unitOfWork.IIncidenciaSolucionPalabrasClave.GetByIdIncSol(id_incSol);
        }

        public bool InsertTags(tagsObjDTO tagsObjDto)
        {
            try
            {
                /*t_incidenciaSolucionPalabrasClave soluciontag = new t_incidenciaSolucionPalabrasClave();
                foreach (var tag in tagsObjDto.tags)
                {
                    soluciontag = new t_incidenciaSolucionPalabrasClave();
                    soluciontag.idIncidenciaSolucion = tagsObjDto.idIncidenciaSolucion;
                    soluciontag.id = 0;
                    if (tag.id == 0)
                    {
                        t_parametroDetalles par = new t_parametroDetalles();
                        par.idParametro = 14;
                        par.codigo = "AUg";
                        par.nombre = tag.nombre;
                        par.esActivo = 1;
                        soluciontag.idPalabraClave = _parametroDetalles.Insert(par);
                    }
                    else
                    {
                        soluciontag.idPalabraClave = tag.id;
                    }

                    Insert(soluciontag);
                }*/
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        public IEnumerable<t_incidenciaSolucionPalabrasClave> GetList()
        {
            return _unitOfWork.IIncidenciaSolucionPalabrasClave.GetList();
        }

        public int Insert(t_incidenciaSolucionPalabrasClave obj)
        {
            return _unitOfWork.IIncidenciaSolucionPalabrasClave.Insert(obj);
        }

        public bool Update(t_incidenciaSolucionPalabrasClave obj)
        {
            return _unitOfWork.IIncidenciaSolucionPalabrasClave.Update(obj);
        }
    }
}
