using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Modelos.Datos;
using Modelos.Datos.Solicitud.DTO;

namespace SGRManagement.Efictec.Controllers.comoon
{
    [Route("api/esActivo")]
    [ApiController]
    public class esActivoController : ControllerBase
    {
        private IModificarActivoLogic _repositorio;
        public ResponseDTO responseDTO = new ResponseDTO();
        public esActivoController(IModificarActivoLogic _repo)
        {
            _repositorio = _repo;
        }
        [HttpPost]
        public IActionResult GetDescripcion([FromBody] solModificarActivoDTO sol)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _repositorio.ModificarActivo(sol.tabla, sol.valor, sol.id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
    }
}
