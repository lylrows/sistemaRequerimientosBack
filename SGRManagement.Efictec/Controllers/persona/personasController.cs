using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Encryption.Interfaz;
using Logica.Negocio.Interfaces.Logic.persona;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Newtonsoft.Json;

namespace SGRManagement.Efictec.Controllers.persona
{
    [Route("api/[controller]")]
    [ApiController]
    public class personasController : ControllerBase
    {
        private IConfiguration _configuration;
        private IT_personasLogic _personas;
        private IEncryptText _encrypt;
        public static string TokenEncriptacion = "fOLXE0jVvPyVsO0d8AFCPyJWVbpBWzzc";
        public ResponseDTO responseDTO =new ResponseDTO();
        public personasController(IEncryptText encrypt, IT_personasLogic t_personas, IConfiguration configuration)
        {
            _personas = t_personas;
            _encrypt = encrypt;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _personas.GetList()));
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
                ; return Ok(responseDTO.Success(responseDTO, _personas.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getUsersByIdEmpresa/{id:int}")]
        public IActionResult getUsersByIdEmpresa(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _personas.getUsersByIdEmpresa(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getUsuariosByEmpresa/{id:int}")]
        public IActionResult getUsuariosByEmpresa(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _personas.getUsuariosByEmpresa(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("GetDescripcion{id:int}")]
        public IActionResult GetDescripcion(int id)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _personas.GetNombres(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }


        [HttpPost]
        public IActionResult Insert([FromBody] personas obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _personas.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("InsertUser")]
        public IActionResult InsertUser([FromBody] personas obj, string contrasenia)
        {
            try
            {

                ; return Ok(responseDTO.Success(responseDTO, _personas.InsertUser(obj, _encrypt.Encriptar(contrasenia, TokenEncriptacion))));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] personas obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _personas.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] personas obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _personas.Delete(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("UploadFoto")]
        public IActionResult UploadFoto(IFormCollection data, IFormFile file)
        {
            ResponseDTO _ResponseDTO = new ResponseDTO();
            try
            {
                var fileName = data["fileName"];
                string ruta = _configuration["DirectorioVirtualFotos"];
                string origen = Path.Combine(ruta, fileName);
                if (System.IO.File.Exists(origen))
                {
                    System.IO.File.Delete(origen);
                }
                using (Stream fileStream = new FileStream(origen, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, "OK"));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("UploadPhotoList")]
        public IActionResult UploadPhotoList(IFormCollection data, List<IFormFile> files)
        {
            ResponseDTO _ResponseDTO = new ResponseDTO();
            try
            {
                t_incidenciaArchivos incidenciaArchivo = new t_incidenciaArchivos();
                
                string ruta = _configuration["DirectorioVirtualFotos"];
                foreach (var file in files)
                {
                    incidenciaArchivo = new t_incidenciaArchivos();
                    incidenciaArchivo = JsonConvert.DeserializeObject<t_incidenciaArchivos>(data["incidenciaArchivo"]);
                    Random random = new Random();
                    int randomNumber = random.Next(11111, 99999);
                    string origen = Path.Combine(ruta, "sgr_" + randomNumber + "_" + file.FileName);
                    incidenciaArchivo.nombreArchivo = "sgr_" + randomNumber + "_" + file.FileName;
                    incidenciaArchivo.urlArchivo = incidenciaArchivo.urlArchivo +"sgr_"+ randomNumber +"_"+ file.FileName;
                    if (System.IO.File.Exists(origen))
                    {
                        System.IO.File.Delete(origen);
                    }
                    using (Stream fileStream = new FileStream(origen, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    _personas.InsertIncidenciaArchivo(incidenciaArchivo);
                }
                return Ok(_ResponseDTO.Success(_ResponseDTO, "OK"));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }
}
