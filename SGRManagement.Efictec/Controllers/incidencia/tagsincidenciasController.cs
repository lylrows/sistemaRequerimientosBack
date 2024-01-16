using Logica.Negocio.Interfaces.Logic.incidencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos;
using System;
using System.Linq;
using Modelos.Datos.Solicitud.DTO;
using Modelos.Datos.Mapeo.Base.Datos.mejora;

namespace SGRManagement.Efictec.Controllers.incidencia
{
    [Route("api/tagsincidencias")]
    [ApiController]
    public class tagsincidenciasController : ControllerBase
    {
        private ITagsincidenciasLogic _tagsincidencias;
        public ResponseDTO _ResponseDTO;
        public tagsincidenciasController(ITagsincidenciasLogic tagsincidencias)
        {
            _tagsincidencias = tagsincidencias;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tagsincidencias.GetList()));
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
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tagsincidencias.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getTagListByIdIncidencia/{id:int}")]
        public IActionResult getTagListByIdIncidencia(int id)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tagsincidencias.getTagListByIdIncidencia(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }


        [HttpPost]
        public IActionResult Insert([FromBody] tagsIncidencias obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tagsincidencias.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("getTagsByIncidencias")]
        public IActionResult getTagsByIncidencias([FromBody] filterDataMejorasDTO obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tagsincidencias.getTagsByIncidencias(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] tagsIncidencias obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tagsincidencias.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        [HttpDelete]
        [Route("{idTag:int}/{incidenciaid:int}")]
        public IActionResult Delete( int idTag, int incidenciaid)
        {
            _ResponseDTO = new ResponseDTO();
            tagsIncidencias obj = _tagsincidencias.GetList().Where(tagIncidencia => tagIncidencia.idTag == idTag && tagIncidencia.idIncidencia == incidenciaid).ToList()[0];
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _tagsincidencias.Delete(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }

}
