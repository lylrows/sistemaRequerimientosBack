using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Logica.Negocio.Interfaces.Logic.persona;

namespace SGRManagement.Efictec.Controllers.incidencia
{
    [Route("api/prioridadhistorial")]
    [ApiController]
    public class prioridadhistorialController : ControllerBase
    {
        private IPrioridadhistorialLogic _prioridadhistorial;
        private IEmpresaANSLogic _ans;
        public ResponseDTO _ResponseDTO;
        public prioridadhistorialController(IPrioridadhistorialLogic prioridadhistorial, IEmpresaANSLogic ans)
        {
            _prioridadhistorial = prioridadhistorial;
            _ans = ans;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _prioridadhistorial.GetList()));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _prioridadhistorial.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }


        [HttpPost]
        public IActionResult Insert([FromBody] prioridadHistorial obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                _ans.getIncidenciaHorarioById(obj.idIncidencia);
                return Ok(_ResponseDTO.Success(_ResponseDTO, _prioridadhistorial.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] prioridadHistorial obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _prioridadhistorial.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] prioridadHistorial obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _prioridadhistorial.Delete(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }

}
