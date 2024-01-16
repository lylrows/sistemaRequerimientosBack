using Microsoft.AspNetCore.Mvc;
using System;
using Logica.Negocio.Interfaces.Logic.mejoras;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.mejora;

namespace SGRManagement.Efictec.Controllers.mejora
{
    [Route("api/[controller]")]
    [ApiController]
    public class MejoraRegistroActividadesController : ControllerBase
    {
        private IMejoraRegistroActividadesLogic _logic;
        public ResponseDTO _ResponseDTO;
        public MejoraRegistroActividadesController(IMejoraRegistroActividadesLogic logic)
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
        public IActionResult Insert([FromBody] t_mejoraRegistroActividades obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _logic.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] t_mejoraRegistroActividades obj)
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
            t_mejoraRegistroActividades obj = _logic.GetById(id);
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
