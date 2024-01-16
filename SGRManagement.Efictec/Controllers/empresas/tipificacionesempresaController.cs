using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logica.Negocio.Interfaces.Logic.empresas;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.empresas;

namespace SGRManagement.Efictec.Controllers.empresas
{
    [Route("api/tipificacionesempresa")]
    [ApiController]
    public class tipificacionesempresaController : ControllerBase
    {
        private ITipificacionesempresaLogic _tipificacionesempresa;
        public ResponseDTO _ResponseDTO;
        public tipificacionesempresaController(ITipificacionesempresaLogic tipificacionesempresa)
        {
            _tipificacionesempresa = tipificacionesempresa;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tipificacionesempresa.GetList()));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getTipificacionByEmpresa/{id:int}")]
        public IActionResult getTipificacionByEmpresa(int id)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tipificacionesempresa.getTipificacionByEmpresa(id)));
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
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tipificacionesempresa.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getEmpresasByGerencia")]
        public IActionResult getEmpresasByGerencia()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tipificacionesempresa.getEmpresasByGerencia()));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getSoporteByAsignacion")]
        public IActionResult getSoporteByAsignacion()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tipificacionesempresa.getSoporteByAsignacion()));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] tipificacionesEmpresa obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tipificacionesempresa.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] tipificacionesEmpresa obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tipificacionesempresa.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            _ResponseDTO = new ResponseDTO();
            tipificacionesEmpresa obj = _tipificacionesempresa.GetById(id);
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tipificacionesempresa.Delete(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }

}
