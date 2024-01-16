using System;
using System.Threading;
using Logica.Negocio.Interfaces.Logic.persona;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.persona;

namespace SGRManagement.Efictec.Controllers.persona
{
    [Route("api/[controller]")]
    [ApiController]
    public class empresaHorariosController : ControllerBase
    {
        private IEmpresaHorariosLogic _logic;
        public ResponseDTO responseDTO = new ResponseDTO();
        public empresaHorariosController(IEmpresaHorariosLogic t_logic)
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

        [HttpGet]
        [Route("getHorarioEmpresaList/{id:int}")]
        public IActionResult getHorarioEmpresaList(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getHorarioEmpresaList(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }


        [HttpPost]
        public IActionResult Insert([FromBody] t_empresaHorarios obj)
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
        public IActionResult Update([FromBody] t_empresaHorarios obj)
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
