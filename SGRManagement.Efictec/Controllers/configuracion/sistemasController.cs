using System;
using System.Threading;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Solicitud.DTO;

namespace SGRManagement.Efictec.Controllers.configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class sistemasController : ControllerBase
    {
        private ISistemasLogic _sistemas;
        public ResponseDTO responseDTO = new ResponseDTO();
        public sistemasController(ISistemasLogic t_sistemas)
        {
            _sistemas = t_sistemas;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _sistemas.GetList()));
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
                ; return Ok(responseDTO.Success(responseDTO, _sistemas.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("validaSistema/{id:int}")]
        public IActionResult validaSistema(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _sistemas.validaSistema(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getSistemasNoAsociados/{id:int}")]
        public IActionResult getSistemasNoAsociados(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _sistemas.getSistemasNoAsociados(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }


        [HttpPost]
        public IActionResult Insert([FromBody] t_sistemas obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _sistemas.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("insertEmpresaSistemas")]
        public IActionResult insertEmpresaSistemas([FromBody] empresaSistemaRequestDTO obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _sistemas.insertEmpresaSistemas(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] t_sistemas obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _sistemas.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
    }
}
