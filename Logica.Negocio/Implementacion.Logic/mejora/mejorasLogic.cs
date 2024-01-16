using System;
using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.mejoras;
using Modelos.Datos.Mapeo.Base.Datos.correo;
using Modelos.Datos.Mapeo.Base.Datos.mejora;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Respuesta.DTO.mejora;
using Modelos.Datos.Solicitud.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.mejora
{
    public class mejorasLogic : IMejorasLogic
    {
        private IUnitOfWork _unitOfWork;

        public mejorasLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_mejoras GetById(int id)
        {
            return _unitOfWork.IMejoras.GetById(id);
        }

        public IEnumerable<t_mejoras> GetList()
        {
            return _unitOfWork.IMejoras.GetList();
        }

        public int Insert(t_mejoras obj)
        {
            //List<usuariosAsignar> usuarios = new List<usuariosAsignar>();
            //int idMejora = 0;
            ////obj.idTicket = _unitOfWork.IMejoras.getIdSecuencialTicket(obj.idSistema, 1);
            //idMejora = _unitOfWork.IMejoras.Insert(obj);
            //usuarios = _unitOfWork.IMejoras.obtenerUsuariosParaAsignarByMejora(idMejora);
            obj.idMejora = _unitOfWork.IIncidencias.getIdSecuencialTicket(obj.idEmpresa, 2);
            int id = _unitOfWork.IMejoras.Insert(obj);
            /*if (id > 0)
            {
                List<string> emalisPara = new List<string>();
                emalisPara = _unitOfWork.IMejoras.getManagerEmailsById(obj.idEmpresa, 63);
                DatosSMTP smtp = new DatosSMTP();
                DatosEmail email = new DatosEmail();
                foreach (var correo in emalisPara)
                {
                    email.Para.Add(correo);                    
                }
                email.Titulo = "SGR - Registo de mejora : ID " + obj.idMejora;
                string bodyhtml = "C:\\SGRFiles\\html\\insertMejoraTemplate.html";
                string fmt = System.IO.File.ReadAllText(bodyhtml);
                fmt = fmt.Replace("[IDMEJORA]", obj.idMejora.ToString());
                fmt = fmt.Replace("[TITULO]", obj.titulo);
                email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };
                _unitOfWork.ICorreo.enviarCorreo(email, smtp);
            }*/
            return id;
        }

        public bool Update(t_mejoras obj)
        {
            if (obj.idEstado == 5)
            {
                obj.fechaAtencion = GetLimaDateTimeNow();
                //enviar correo a usuario que prueba idUsuarioAsignado
                approverUserData userData = new approverUserData();
                userData = _unitOfWork.IMejoras.getApproverUserDataById(obj.id);
                List<string> emalisPara = new List<string>();
                emalisPara = _unitOfWork.IMejoras.getManagerEmailsById(obj.idEmpresa, 63);
                DatosSMTP smtp = new DatosSMTP();
                DatosEmail email = new DatosEmail();
                email.Para.Add(userData.email);
                foreach (var correo in emalisPara)
                {
                    email.ConCopia.Add(correo);
                }
                email.Titulo = "SGR - Solicito conformidad de mejora : ID " + obj.idMejora;
                string bodyhtml = "C:\\SGRFiles\\html\\approverMejoraTemplate.html";
                string fmt = System.IO.File.ReadAllText(bodyhtml);
                fmt = fmt.Replace("[NOMBRE_USUARIO]", userData.usuarioAsignado);
                fmt = fmt.Replace("[IDMEJORA]", obj.idMejora.ToString());
                fmt = fmt.Replace("[TITULO]", userData.titulo);
                fmt = fmt.Replace("[DESCRIPCION]", userData.descripcion);
                email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };
                _unitOfWork.ICorreo.enviarCorreo(email, smtp);
            }
            return _unitOfWork.IMejoras.Update(obj);
        }
        private DateTime GetLimaDateTimeNow()
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo limaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime limaDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, limaTimeZone);
            return limaDateTime;
        }

        public bool Delete(t_mejoras obj)
        {
            return _unitOfWork.IMejoras.Delete(obj);
        }

        public IEnumerable<usuariosAsignar> obtenerUsuariosParaAsignarByMejora(in int id)
        {
            return _unitOfWork.IMejoras.obtenerUsuariosParaAsignarByMejora(id);
        }
        public List<mejoraGridListDTO> obtenerMejoraPorIdUsuario(filterDataDTO obj)
        {
            return _unitOfWork.IMejoras.obtenerMejoraPorIdUsuario(obj);
        }
        public List<mejoraComplete> obtenerMejoraPorIdClienteEmpresa(int idUsuario)
        {
            return _unitOfWork.IMejoras.obtenerMejoraPorIdClienteEmpresa(idUsuario);
        }

        public mejoraDTO getMejoraById(int id)
        {
            mejoraDTO mejoraDTO = new mejoraDTO();
            mejoraDTO.mejora = _unitOfWork.IMejoras.GetById(id);
            mejoraDTO.mejoraArchivos = (List<t_mejoraArchivos>) _unitOfWork.IMejoraArchivos.GetList();
            mejoraDTO.mejoraArchivos = mejoraDTO.mejoraArchivos.FindAll(x => x.idMejora == id);
            mejoraDTO.mejoraActividades = (List<t_mejoraRegistroActividades>) _unitOfWork.IRegistroActividades.GetList();
            mejoraDTO.mejoraActividades = mejoraDTO.mejoraActividades.FindAll(x => x.idMejora == id);
            return mejoraDTO;
        }

        public List<ticketsAsosciadosDTO> getTicketsAsosciados(ticketsAsosciadosFilter obj)
        {
            return _unitOfWork.IMejoras.getTicketsAsosciados(obj);
        }
    }
}
