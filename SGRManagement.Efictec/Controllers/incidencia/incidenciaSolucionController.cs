using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Modelos.Datos.Solicitud.DTO;

namespace SGRManagement.Efictec.Controllers.incidencia
{
    [Route("api/[controller]")]
    [ApiController]
    public class incidenciaSolucionController : ControllerBase
    {
        private IIncidenciaSolucionLogic _logic;
        public ResponseDTO responseDTO = new ResponseDTO();
        public incidenciaSolucionController(IIncidenciaSolucionLogic t_logic)
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
        [Route("InsertObj")]
        public IActionResult Insert([FromBody] incidenciaSolArchivosPalabras obj)
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

        [HttpPost]
        public IActionResult Insert([FromBody] t_incidenciaSolucion obj)
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
        public IActionResult Update([FromBody] t_incidenciaSolucion obj)
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
        [HttpGet]
        [Route("getIncidenciaSolucionesByFilter/{id:int}")]
        public IActionResult getIncidenciaComentariosArchivosByFilter( int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciaSolucionesFilter(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getIncidenciaSolucionesByTagFilter/")]
        public IActionResult getIncidenciaComentariosArchivosByTagFilter(List<palabrasClave_tag> req)
        {
            if(req.Count()!=0)
            {
                try
                {
                    ; return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasSolucionesByTagFilter(req)));
                }
                catch (Exception e)
                {
                    return BadRequest(responseDTO.Failed(responseDTO, e.Message));
                }
            }
            else
            {
                try
                {
                    ; return Ok();// (responseDTO.Success(responseDTO, _logic.getIncidenciaSolucionesFilter()));
                }
                catch (Exception e)
                {
                    return BadRequest(responseDTO.Failed(responseDTO, e.Message));
                }
            }
        }
        [HttpGet]
        [Route("getSolutionById/{id:int}")]
        public IActionResult getSolutionById(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getSolutionById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpGet]
        [Route("getSolutionImg/{id:int}")]
        public IActionResult getSolutionImg(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getSolutionImg(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
    }
}
