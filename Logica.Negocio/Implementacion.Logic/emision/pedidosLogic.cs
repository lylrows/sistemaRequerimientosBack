using Logica.Negocio.Interfaces.Logic.emision;
using Modelos.Datos.Mapeo.Base.Datos.correo;
using Modelos.Datos.Mapeo.Base.Datos.emision;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Solicitud.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.emision
{
    public class pedidosLogic : IPedidosLogic
    {
        private IUnitOfWork _unitOfWork;

        public pedidosLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public pedidos GetById(int id)
        {
            return _unitOfWork.IPedidos.GetById(id);
        }

        public IEnumerable<pedidos> GetList()
        {
            return _unitOfWork.IPedidos.GetList();
        }

        public int Insert(pedidos obj)
        {

            return _unitOfWork.IPedidos.Insert(obj);
        }

        public bool Update(pedidos obj)
        {
            return _unitOfWork.IPedidos.Update(obj);
        }

        public bool Delete(pedidos obj)
        {
            return _unitOfWork.IPedidos.Delete(obj);
        }

        public void insertArchivos(pedidosArchivos archivos)
        {
            _unitOfWork.IPedidosarchivos.Insert(archivos);
        }

        public List<emissionOrdersGrid> getEmissionOrdersGrid()
        {
            return _unitOfWork.IPedidosarchivos.getEmissionOrdersGrid();
        }

        public ResultadoEnvio envioCorreoPedido(int idPedido, pedidos obj, List<string> adjuntos, string ruta)
        {            
            List<string> emalisPara = new List<string>();
            string[] emailsCopy = obj.emailCopyList.Split(',');
            var adjuntosHtml = new StringBuilder();
            emalisPara = _unitOfWork.IMejoras.getBpoEmailsById(1007, obj.idUsuarioRegistro);
            DatosSMTP smtp = new DatosSMTP();
            DatosEmail email = new DatosEmail();
            //email.Para.Add("walter.atuncar@efitec-corp.com");
            //email.ConCopia.Add("walter150976@gmail.com");
            foreach (var correo in emalisPara)
            {
                email.Para.Add(correo);
            }
            foreach (var correo in emailsCopy)
            {
                email.ConCopia.Add(correo);
            }
            foreach (var ad in adjuntos)
            {
                string name = ad.Replace(ruta, "");
                adjuntosHtml.Append($"<li>{name}</li>");
            }
            email.Adjuntos = adjuntos;
            email.Titulo = obj.titulo;
            string bodyhtml = "C:\\SGRFiles\\html\\createPedidoEmisionTemplate.html";
            string fmt = System.IO.File.ReadAllText(bodyhtml);
            fmt = fmt.Replace("[IDPEDIDO]", idPedido.ToString());
            fmt = fmt.Replace("[TITULO]", obj.titulo);
            fmt = fmt.Replace("[DESCRIPCION]", obj.descripcion);
            fmt = fmt.Replace("[ADJUNTOS]", adjuntosHtml.ToString());
            email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };
            return _unitOfWork.ICorreo.enviarCorreo(email, smtp);
        }

        public List<asignarPedido> getPboUsers(int id)
        {
            return _unitOfWork.IPedidosarchivos.getPboUsers(id);
        }

        public bool asignarPedido(int idUsuario, int id)
        {
            pedidos obj = _unitOfWork.IPedidos.GetById(id);
            obj.idUsuarioAtendido = idUsuario;
            if (obj.idEstado != 3)
            {
                obj.idEstado = 2;
            }
            return _unitOfWork.IPedidos.Update(obj);
        }

        public bool aprobacionCorreo(aprobacionCorreoDTO obj)
        {
            ResultadoEnvio resultadoEnvio = new ResultadoEnvio();
            pedidos objPedido = _unitOfWork.IPedidos.GetById(obj.id);
            objPedido.idEstado = 4;
            _unitOfWork.IPedidos.Update(objPedido);
            DatosSMTP smtp = new DatosSMTP();
            DatosEmail email = new DatosEmail();
            foreach (var correo in obj.emailToList)
            {
                email.Para.Add(correo);
            }
            foreach (var correo in objPedido.emailCopyList.Split(','))
            {
                email.ConCopia.Add(correo);
            }
            email.Titulo = obj.titulo;
            string bodyhtml = "C:\\SGRFiles\\html\\aprobacionEmisionTemplate.html";
            string fmt = System.IO.File.ReadAllText(bodyhtml);
            fmt = fmt.Replace("[DESCRIPCION]", obj.comentario);
            email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };
            resultadoEnvio = _unitOfWork.ICorreo.enviarCorreo(email, smtp);
            return resultadoEnvio.FueExitoso;
        }

        public bool respuestaEmision(aprobacionCorreoDTO obj)
        {
            ResultadoEnvio resultadoEnvio = new ResultadoEnvio();
            pedidos objPedido = _unitOfWork.IPedidos.GetById(obj.id);
            objPedido.idEstado = 3;
            objPedido.fechaAtencion = GetLimaDateTimeNow();
            _unitOfWork.IPedidos.Update(objPedido);
            DatosSMTP smtp = new DatosSMTP();
            DatosEmail email = new DatosEmail();
            List<personas> personasList = (List<personas>)_unitOfWork.IT_personas.GetList();
            personasList = personasList.FindAll(x => x.id == objPedido.idUsuarioRegistro || x.id == objPedido.idUsuarioAtendido);
            foreach (var persona in personasList)
            {
                email.Para.Add(persona.email);
            }
            foreach (var correo in objPedido.emailCopyList.Split(','))
            {
                email.ConCopia.Add(correo);
            }
            //email.Para.Add("walter.atuncar@efitec-corp.com");
            //email.ConCopia.Add("walter150976@gmail.com");
            email.Titulo = obj.titulo;
            string bodyhtml = "C:\\SGRFiles\\html\\aprobacionEmisionTemplate.html";
            string fmt = System.IO.File.ReadAllText(bodyhtml);
            fmt = fmt.Replace("[DESCRIPCION]", obj.comentario);
            email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };
            resultadoEnvio = _unitOfWork.ICorreo.enviarCorreo(email, smtp);
            pedidosRespuesta respuesta = new pedidosRespuesta();
            var respuestaList = (List<pedidosRespuesta>) _unitOfWork.IPedidosrespuesta.GetList();
            respuesta = respuestaList.Find(x => x.idPedido == obj.id);

            if (respuesta == null)
            {
                respuesta = new pedidosRespuesta();
                respuesta.idPedido = obj.id;
                respuesta.titulo = obj.titulo;
                respuesta.comentario = obj.comentario;
                _unitOfWork.IPedidosrespuesta.Insert(respuesta);
            }
            else
            {                
                respuesta.idPedido = obj.id;
                respuesta.titulo = obj.titulo;
                respuesta.comentario = obj.comentario;
                _unitOfWork.IPedidosrespuesta.Update(respuesta);
            }
            return resultadoEnvio.FueExitoso;
        }

        private DateTime GetLimaDateTimeNow()
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo limaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime limaDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, limaTimeZone);
            return limaDateTime;
        }
    }
}
