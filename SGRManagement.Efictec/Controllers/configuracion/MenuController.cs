using System;
using System.Threading;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGRManagement.Efictec.Controllers.configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IMenuLogic _menu;
        public ResponseDTO responseDTO = new ResponseDTO();
        public MenuController(IMenuLogic t_menu)
        {
            _menu = t_menu;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _menu.GetList()));
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
                ; return Ok(responseDTO.Success(responseDTO, _menu.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("GetByIdRole{id:int}")]
        public IActionResult GetDescripcion(int id)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _menu.GetByIdRole(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }


        [HttpPost]
        public IActionResult Insert([FromBody] t_menu obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _menu.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] t_menu obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _menu.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] t_menu obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _menu.Delete(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
    }
}
