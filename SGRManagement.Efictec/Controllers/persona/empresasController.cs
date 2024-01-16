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
    public class empresasController : ControllerBase
    {
        private IEmpresasLogic _empresas;
        public ResponseDTO responseDTO = new ResponseDTO();
        public empresasController(IEmpresasLogic t_empresas)
        {
            _empresas = t_empresas;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _empresas.GetList()));
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
                ; return Ok(responseDTO.Success(responseDTO, _empresas.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getEmpresaByIdUsuario/{id:int}")]
        public IActionResult getEmpresaByIdUsuario(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _empresas.getEmpresaByIdUsuario(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }



        [HttpPost]
        public IActionResult Insert([FromBody] t_empresa obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _empresas.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] t_empresa obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _empresas.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
    }
}
