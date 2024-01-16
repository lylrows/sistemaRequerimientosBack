using System;
using System.Threading;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;

namespace SGRManagement.Efictec.Controllers.configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class empresaSistemaUsuarios : ControllerBase
    {
        private IEmpresaSistemaUsuariosLogic _logic;
        public ResponseDTO responseDTO = new ResponseDTO();
        public empresaSistemaUsuarios(IEmpresaSistemaUsuariosLogic t_logic)
        {
            _logic = t_logic;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.GetList()));
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
                ; return Ok(responseDTO.Success(responseDTO, _logic.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] t_empresaSistemaUsuarios obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] t_empresaSistemaUsuarios obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
    }
}
