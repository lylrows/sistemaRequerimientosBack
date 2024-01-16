using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.mejoras;
using Modelos.Datos.Mapeo.Base.Datos.correo;
using Modelos.Datos.Mapeo.Base.Datos.mejora;
using Modelos.Datos.Respuesta.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.mejora
{
    public class mejoraAsignacionesLogic : IMejoraAsignacionesLogic
    {
        private IUnitOfWork _unitOfWork;

        public mejoraAsignacionesLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_mejoraAsignaciones GetById(int id)
        {
            return _unitOfWork.IMejoraAsignaciones.GetById(id);
        }

        public IEnumerable<t_mejoraAsignaciones> GetList()
        {
            return _unitOfWork.IMejoraAsignaciones.GetList();
        }

        public int Insert(t_mejoraAsignaciones obj)
        {
            int id = _unitOfWork.IMejoraAsignaciones.Insert(obj);
            if (id > 0)
            {
                t_mejoras mejora = _unitOfWork.IMejoras.GetById(obj.idMejora);
                approverUserData userData = new approverUserData();
                userData = _unitOfWork.IMejoras.getApproverUserDataById(obj.id);
                DatosSMTP smtp = new DatosSMTP();
                DatosEmail email = new DatosEmail();
                email.Para.Add(userData.emailSoporte);
                email.ConCopia.Add("martin.grillo@efitec-corp.com");
                email.Titulo = "SGR - Asignación de mejora : ID " + obj.idMejora;
                string bodyhtml = "C:\\SGRFiles\\html\\asignacionMejoraTemplate.html";
                string fmt = System.IO.File.ReadAllText(bodyhtml);
                fmt = fmt.Replace("[NOMBRE_USUARIO]", userData.soporteAsignado);
                fmt = fmt.Replace("[IDMEJORA]", obj.idMejora.ToString());
                fmt = fmt.Replace("[TITULO]", userData.titulo);
                fmt = fmt.Replace("[DESCRIPCION]", userData.descripcion);
                email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };
                _unitOfWork.ICorreo.enviarCorreo(email, smtp);
            }
           
            return id;
        }

        public bool Update(t_mejoraAsignaciones obj)
        {
            return _unitOfWork.IMejoraAsignaciones.Update(obj);
        }

        public bool Delete(t_mejoraAsignaciones obj)
        {
            return _unitOfWork.IMejoraAsignaciones.Delete(obj);
        }
    }
}
