using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Encryption.Interfaz;
using Logica.Negocio.Interfaces.Logic.login;
using Modelos.Datos;
using Modelos.Datos.Solicitud.DTO;

namespace SGRManagement.Efictec.Controllers.login
{
    [Route("api/login")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private ICredencialesLogic _credenciales;
        private IEncryptText _encrypt;
        public ResponseDTO _ResponseDTO;
        public static string TokenEncriptacion = "fOLXE0jVvPyVsO0d8AFCPyJWVbpBWzzc";

        public loginController(IEncryptText encrypt, ICredencialesLogic credenciales)
        {
            _credenciales = credenciales;
            _encrypt = encrypt;
        }

        [HttpPost("login")]
        public IActionResult LoguearUsuario([FromBody] CredencialesUsuaroBE usuario)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                usuario.contrasenia = _encrypt.Encriptar(usuario.contrasenia, TokenEncriptacion);
                var obj = _credenciales.LoguearUsuario(usuario);
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, obj));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("GenerarKey")]
        public IActionResult GenerarKey()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, _encrypt.GenerarKey()));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("Encriptar")]
        public IActionResult Encriptar([FromBody] encripta obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, _encrypt.Encriptar(obj.texto, TokenEncriptacion)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("Desencriptar")]
        public IActionResult Desencriptar([FromBody] encripta obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, _encrypt.Desencriptar(obj.texto, TokenEncriptacion)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }
}
