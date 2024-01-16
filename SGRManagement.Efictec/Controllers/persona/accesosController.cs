using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Encryption.Interfaz;
using Logica.Negocio.Interfaces.Logic.persona;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.persona;

namespace SGRManagement.Efictec.Controllers.persona
{
    [Route("api/accesos")]
    [ApiController]
    public class accesosController : ControllerBase
    {
        private IAccesosLogic _accesos;
        private IEncryptText _encrypt;
        public ResponseDTO _ResponseDTO;
        public static string TokenEncriptacion = "fOLXE0jVvPyVsO0d8AFCPyJWVbpBWzzc";
        public accesosController(IEncryptText encrypt, IAccesosLogic accesos)
        {
            _accesos = accesos;
            _encrypt = encrypt;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, _accesos.GetList()));
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
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, _accesos.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getContraseniaByIdUser/{id:int}")]
        public IActionResult getContraseniaByIdUser(int id)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                string contrasenia = _accesos.getContraseniaByIdUser(id);
                contrasenia = _encrypt.Desencriptar(contrasenia, TokenEncriptacion);
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, contrasenia));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] accesos obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                obj.contrasenia = _encrypt.Encriptar(obj.contrasenia, TokenEncriptacion);
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, _accesos.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] accesos obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, _accesos.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] accesos obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, _accesos.Delete(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        [HttpGet]
        [Route("generadorCodigo/{usuario}")]
        public IActionResult GetById(string usuario)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, _accesos.generadorCodigo(usuario)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        [HttpGet]
        [Route("validarCodigo/{codigo:int}/{usuario}")]
        public IActionResult GetById(int codigo, string usuario)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, _accesos.validarCodigo(codigo, usuario)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        [HttpGet]
        [Route("actualizaContrasenia/{contrasenia}/{usuario}")]
        public IActionResult actualizaContrasenia(string contrasenia, string usuario)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                contrasenia = _encrypt.Encriptar(contrasenia, TokenEncriptacion);
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, _accesos.actualizaContrasenia(contrasenia, usuario)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }
}
