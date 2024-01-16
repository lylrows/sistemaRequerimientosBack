using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Solicitud.DTO;
using Modelos.Datos.Utils;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SGRManagement.Efictec.Controllers.configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class ckeditorUploadController : ControllerBase
    {
        private readonly ILogger<ckeditorUploadController> _logger;
        private readonly AppSettings _appSettings;
        public ckeditorUploadController(IOptions<AppSettings> appSettings, ILogger<ckeditorUploadController> logger)
        {
            this._logger = logger;
            _appSettings = appSettings.Value;
        }
        
        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(_appSettings.ckUpload, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Ok(new { message = "Archivo subido exitosamente." });
            }
            return BadRequest("Archivo no encontrado o vacío.");
        }
    }
}
