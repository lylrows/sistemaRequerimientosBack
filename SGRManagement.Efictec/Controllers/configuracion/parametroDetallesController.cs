using Logica.Negocio.Interfaces.Logic.configuracion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SGRManagement.Efictec.Controllers.configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class parametroDetallesController : ControllerBase
    {
        private IParametroDetalles _parametroDetalles;
        public ResponseDTO responseDTO = new ResponseDTO();
        public parametroDetallesController(IParametroDetalles t_parametroDetalles)
        {
            _parametroDetalles = t_parametroDetalles;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _parametroDetalles.GetList()));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _parametroDetalles.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }


        [HttpPost]
        public IActionResult Insert([FromBody] t_parametroDetalles obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _parametroDetalles.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] t_parametroDetalles obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _parametroDetalles.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
    }
}
