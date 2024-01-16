using Logica.Negocio.Interfaces.Logic.configuracion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos;
using System;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SGRManagement.Efictec.Controllers.configuracion
{
    [Route("api/mural")]
    [ApiController]
    public class muralController : ControllerBase
    {
        private IConfiguration _configuration;
        private IMuralLogic _mural;
        public ResponseDTO _ResponseDTO;
        public muralController(IMuralLogic mural, IConfiguration configuration)
        {
            _mural = mural;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mural.GetList()));
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
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mural.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert(IFormCollection data, IFormFile file)
        {
            string ruta = _configuration["DirectorioVirtualFotos"];
            mural obj = new mural();
            obj = JsonConvert.DeserializeObject<mural>(data["message"]);
            Random random = new Random();
            int randomNumber = random.Next(11111, 99999);
            string origen = Path.Combine(ruta, "sgr_" + randomNumber + "Mural_" + file.FileName);
            obj.urlFile = Path.Combine("https://sgrservices.efitec-corp.com:4443/users/users/", "sgr_" + randomNumber + "Mural_" + file.FileName); ;
            _ResponseDTO = new ResponseDTO();
            try
            {
                if (System.IO.File.Exists(origen))
                {
                    System.IO.File.Delete(origen);
                }
                using (Stream fileStream = new FileStream(origen, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mural.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] mural obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mural.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] mural obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mural.Delete(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }

}
