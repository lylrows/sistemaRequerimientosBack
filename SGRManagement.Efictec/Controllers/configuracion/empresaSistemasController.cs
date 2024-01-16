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
    public class empresaSistemasController : ControllerBase
    {
        private IEmpresaSistemasLogic _logic;
        public ResponseDTO responseDTO = new ResponseDTO();
        public empresaSistemasController(IEmpresaSistemasLogic t_logic)
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
        [Route("getSistemasEmpresaByUser/{id:int}")]
        public IActionResult getSistemasEmpresaByUser(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getSistemasEmpresaByUser(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getSistemasByIdUsuario/{id:int}")]
        public IActionResult getSistemasByIdUsuario(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getSistemasByIdUsuario(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("validaUsuarioAsociado/{idSistema:int}/{idEmpresa:int}")]
        public IActionResult validaUsuarioAsociado(int idSistema, int idEmpresa)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.validaUsuarioAsociado(idSistema, idEmpresa)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("deleteEmpresaSistemas/{idEmpresa:int}/{idSistema:int}")]
        public IActionResult deleteEmpresaSistemas(int idEmpresa, int idSistema)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.deleteEmpresaSistemas(idEmpresa, idSistema)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getSistemasPorAsignarByIdUsuario/{id:int}")]
        public IActionResult getSistemasPorAsignarByIdUsuario(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getSistemasPorAsignarByIdUsuario(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getSistemasByIdEmpresa/{id:int}")]
        public IActionResult getSistemasByIdEmpresa(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getSistemasByIdEmpresa(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }


        [HttpPost]
        public IActionResult Insert([FromBody] t_empresaSistemas obj)
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
        public IActionResult Update([FromBody] t_empresaSistemas obj)
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
