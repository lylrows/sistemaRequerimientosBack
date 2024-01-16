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
    [Route("api/tipoincidenciasempresa")]
    [ApiController]
    public class tipoincidenciasempresaController : ControllerBase
    {
        private ITipoincidenciasempresaLogic _tipoincidenciasempresa;
        public ResponseDTO _ResponseDTO;
        public tipoincidenciasempresaController(ITipoincidenciasempresaLogic tipoincidenciasempresa)
        {
            _tipoincidenciasempresa = tipoincidenciasempresa;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tipoincidenciasempresa.GetList()));
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
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tipoincidenciasempresa.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        
        [HttpPost]
        public IActionResult Insert([FromBody] tipoIncidenciasEmpresa obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tipoincidenciasempresa.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] tipoIncidenciasEmpresa obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tipoincidenciasempresa.Update(obj)));
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
            tipoIncidenciasEmpresa obj = _tipoincidenciasempresa.GetById(id);
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tipoincidenciasempresa.Delete(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }
}
