using System;
using System.Collections.Generic;
using System.Text;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Solicitud.DTO;
using Unidad.Trabajo;


namespace Logica.Negocio.Implementacion.Logic.configuracion
{
    public class sistemasLogic :ISistemasLogic
    {
        private IUnitOfWork _unitOfWork;
        private IEmpresaSistemasLogic _empSist;
        private IParametroDetalles _parametroDetalles;
        public sistemasLogic(IUnitOfWork unitOfWork, IEmpresaSistemasLogic empSist, IParametroDetalles parametroDetalles)
        {
            _unitOfWork = unitOfWork;
            _empSist = empSist;
            _parametroDetalles = parametroDetalles;
        }

        public t_sistemas GetById(int id)
        {
            return _unitOfWork.ISistemas.GetById(id);
        }

        public int insertEmpresaSistemas(empresaSistemaRequestDTO dto)
        {
           dto.empresaSistema.idSistema = _unitOfWork.ISistemas.Insert(dto.sistema);

           return _empSist.Insert(dto.empresaSistema);
        }

        public int validaSistema(in int id)
        {
            return _unitOfWork.ISistemas.validaSistema(id);
        }

        public IEnumerable<noAsignadosDTO> getSistemasNoAsociados(in int id)
        {
            return _unitOfWork.ISistemas.getSistemasNoAsociados(id);
        }

        public IEnumerable<sistemasDTO> GetList()
        {
            List<sistemasDTO> sistemasDTOs = new List<sistemasDTO>();
            var objs = _unitOfWork.ISistemas.GetList() as List<t_sistemas>;
            objs = objs?.FindAll(x => x.esActivo == 1);
            var dets = _parametroDetalles.GetList() as List<t_parametroDetalles>;
            dets = dets.FindAll(x => x.idParametro == 6);
            foreach (var tSistemase in objs)
            {
                sistemasDTO sistemasDTO = new sistemasDTO();
                sistemasDTO.id = tSistemase.id;
                sistemasDTO.codigoSistema = tSistemase.codigoSistema;
                sistemasDTO.nombreSistema = tSistemase.nombreSistema;
                sistemasDTO.descripcion = tSistemase.descripcion;
                sistemasDTO.tipoSistema = tSistemase.tipoSistema; 
                sistemasDTO.descripcionTipoSistema = tSistemase.descripcionTipoSistema;
                sistemasDTO.intervaloAtencion = tSistemase.intervaloAtencion;
                sistemasDTO.esActivo = tSistemase.esActivo;
                foreach (var tParametroDetallese in dets)
                {
                    if (tSistemase.tipoSistema == tParametroDetallese.valorEntero)
                    {
                        sistemasDTO.tipoSistemaNombre = tParametroDetallese.nombre;
                        break;
                    }
                }

                sistemasDTOs.Add(sistemasDTO);
            }
            return sistemasDTOs;
        }

        public int Insert(t_sistemas obj)
        {
            return _unitOfWork.ISistemas.Insert(obj);
        }

        public bool Update(t_sistemas obj)
        {
            return _unitOfWork.ISistemas.Update(obj);
        }
    }
}
