using Logica.Negocio.Interfaces.Logic.emision;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos.Mapeo.Base.Datos.emision;
using Modelos.Datos;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;
using Modelos.Datos.Mapeo.Base.Datos.correo;
using Modelos.Datos.Solicitud.DTO;

namespace SGRManagement.Efictec.Controllers.emision
{
    [Route("api/pedidos")]
    [ApiController]
    public class pedidosController : ControllerBase
    {
        private IPedidosLogic _pedidos;
        private IConfiguration _configuration;
        public ResponseDTO _ResponseDTO;
        public pedidosController(IPedidosLogic pedidos, IConfiguration configuration)
        {
            _pedidos = pedidos;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _pedidos.GetList()));
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
                return Ok(_ResponseDTO.Success(_ResponseDTO, _pedidos.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getPboUsers/{id:int}")]
        public IActionResult getPboUsers(int id)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _pedidos.getPboUsers(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("asignarPedido/{idUsuario:int}/{id:int}")]
        public IActionResult asignarPedido(int idUsuario, int id)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _pedidos.asignarPedido(idUsuario, id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }


        [HttpGet]
        [Route("getEmissionOrdersGrid")]
        public IActionResult getEmissionOrdersGrid()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _pedidos.getEmissionOrdersGrid()));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] pedidos obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _pedidos.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("aprobacionCorreo")]
        public IActionResult aprobacionCorreo([FromBody] aprobacionCorreoDTO obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _pedidos.aprobacionCorreo(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("respuestaEmision")]
        public IActionResult respuestaEmision([FromBody] aprobacionCorreoDTO obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _pedidos.respuestaEmision(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }


        [HttpPost]
        [Route("insertEmisionPedido")]
        public IActionResult insertEmisionPedido(IFormCollection data, List<IFormFile> files)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                pedidos obj = JsonConvert.DeserializeObject<pedidos>(data["pedidos"]);               
                string ruta = _configuration["DirectorioVirtualFotos"];
                int idPedido = _pedidos.Insert(obj);
                List<string> adjuntos = new List<string>();
                ResultadoEnvio envio = new ResultadoEnvio();
                foreach (var file in files)
                {
                    pedidosArchivos archivos = new pedidosArchivos();
                    archivos.idPedido = idPedido;
                    archivos.nombreArchivo = "sgr_pedido_" + idPedido + "_" + file.FileName;                    
                    string origen = Path.Combine(ruta, archivos.nombreArchivo);
                    archivos.urlArchivo = Path.Combine(@"https://sgrservices.efitec-corp.com:4443/users/users/", archivos.nombreArchivo); ;
                    archivos.idUsuario = obj.idUsuarioRegistro;
                    if (System.IO.File.Exists(origen))
                    {
                        System.IO.File.Delete(origen);
                    }
                    using (Stream fileStream = new FileStream(origen, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    _pedidos.insertArchivos(archivos);
                    adjuntos.Add(origen);
                }
                envio = _pedidos.envioCorreoPedido(idPedido, obj, adjuntos, ruta);
                return Ok(_ResponseDTO.Success(_ResponseDTO, idPedido));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] pedidos obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _pedidos.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] pedidos obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _pedidos.Delete(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }
}
