using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.mejoras;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.mejora;
using System.Linq;

namespace SGRManagement.Efictec.Controllers.mejora
{
    [Route("api/[controller]")]
    [ApiController]
    public class MejoraAsignacionesController : ControllerBase
    {
        private IMejoraAsignacionesLogic _logic;
        public ResponseDTO _ResponseDTO;
        public MejoraAsignacionesController(IMejoraAsignacionesLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _logic.GetList()));
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
                return Ok(_ResponseDTO.Success(_ResponseDTO, _logic.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] t_mejoraAsignaciones obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                List<t_mejoraAsignaciones> ListMejoras = (List<t_mejoraAsignaciones>)_logic.GetList();

                t_mejoraAsignaciones obj2 = ListMejoras.Find( x => x.idMejora == obj.idMejora);
                if (obj2 != null)
                {
                    _logic.Delete(obj2);
                }                
                return Ok(_ResponseDTO.Success(_ResponseDTO, _logic.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] t_mejoraAsignaciones obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _logic.Update(obj)));
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
            List<t_mejoraAsignaciones> list = new List<t_mejoraAsignaciones>();
            list = (List<t_mejoraAsignaciones>) _logic.GetList();
            t_mejoraAsignaciones obj = list.FindAll(x => x.idMejora == id)[0];
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _logic.Delete(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }
}
