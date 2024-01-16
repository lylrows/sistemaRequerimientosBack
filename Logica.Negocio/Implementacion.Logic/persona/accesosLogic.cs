using System;
using System.Collections.Generic;
using System.Text;
using Encryption.Interfaz;
using Logica.Negocio.Interfaces.Logic.correo;
using Logica.Negocio.Interfaces.Logic.persona;
using Modelos.Datos.Mapeo.Base.Datos.correo;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Utils;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.persona
{
    public class accesosLogic : IAccesosLogic
    {
        private IUnitOfWork _unitOfWork;
        private ICorreoLogic _correo;
        private IT_personasLogic _persona;
        private IEncryptText _encrypt;
        public static string TokenEncriptacion = "fOLXE0jVvPyVsO0d8AFCPyJWVbpBWzzc";
        //private readonly AppSettings _appSettings;

        public accesosLogic(IEncryptText encrypt, IUnitOfWork unitOfWork, ICorreoLogic e_correo, IT_personasLogic persona
            //, AppSettings appSettings
            )
        {
            _unitOfWork = unitOfWork;
            _correo = e_correo;
            _persona = persona;
            _encrypt = encrypt;
            //_appSettings = appSettings;
        }

        public accesos GetById(int id)
        {
            return _unitOfWork.IAccesos.GetById(id);
        }

        public IEnumerable<accesos> GetList()
        {
            return _unitOfWork.IAccesos.GetList();
        }

        public int Insert(accesos obj)
        {
            int rpta = _unitOfWork.IAccesos.Insert(obj);
            personas per = _persona.GetById(obj.idPersona);
            DatosSMTP smtp = new DatosSMTP();
            DatosEmail email = new DatosEmail();
            email.Para.Add(obj.usuario);
            email.Titulo = "SGR - NOTIFICACION DE EDICIÓN DE ACCESO";
            string bodyhtml = "C:\\SGRFiles\\html\\insertAccesoTemplate.html";
            string fmt = System.IO.File.ReadAllText(bodyhtml);
            fmt = fmt.Replace("[NOMBR]", per.nombres);
            fmt = fmt.Replace("[APELL]", per.apellidos);
            fmt = fmt.Replace("[USUARIO]", obj.usuario);
            fmt = fmt.Replace("[PASS]", _encrypt.Desencriptar(obj.contrasenia,TokenEncriptacion));
            email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };
            _correo.enviarCorreo(email, smtp);
            return rpta;
        }

        public bool Update(accesos obj)
        {
            bool rpta= _unitOfWork.IAccesos.Update(obj);
            
            return rpta;
        }

        public bool Delete(accesos obj)
        {
            return _unitOfWork.IAccesos.Delete(obj);
        }

        public ResultadoEnvio generadorCodigo(string usuario)
        {
            DatosSMTP smtp = new DatosSMTP();
            DatosEmail email = new DatosEmail();
            int codigo = _unitOfWork.IAccesos.generadorCodigo(usuario);
            email.Para.Add(usuario);
            email.Titulo = "SGR - EFITEC CÓDIGO DE VALIDACIÓN";
            string bodyhtml = "C:\\SGRFiles\\html\\codigoValidacionTemplate.html";
            string fmt = System.IO.File.ReadAllText(bodyhtml);
            fmt = fmt.Replace("[CODE]", codigo.ToString());
            email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };
            ResultadoEnvio result = _correo.enviarCorreo(email, smtp);

            return result;
        }
        public bool validarCodigo(int codigo, string usuario)
		{
			return _unitOfWork.IAccesos.validarCodigo(codigo, usuario); 
		}

        public bool actualizaContrasenia(string contrasenia, string usuario)
        {
            var result= _unitOfWork.IAccesos.actualizaContrasenia(contrasenia, usuario);
            List<accesos> usuariolist = (List<accesos>) GetList();
            accesos obj= usuariolist.FindAll(x => x.usuario == usuario)[0];
            personas per = _persona.GetById(obj.idPersona);
            DatosSMTP smtp = new DatosSMTP();
            DatosEmail email = new DatosEmail();
            email.Para.Add(usuario);
            email.Titulo = "SGR - NOTIFICACION DE EDICIÓN DE ACCESO";
            string bodyhtml = "C:\\SGRFiles\\html\\updateAccesoTemplate.html";
            string fmt = System.IO.File.ReadAllText(bodyhtml);
            fmt = fmt.Replace("[NOMBR]", per.nombres);
            fmt = fmt.Replace("[APELL]", per.apellidos);
            fmt = fmt.Replace("[USUARIO]", obj.usuario);
            fmt = fmt.Replace("[PASS]", _encrypt.Desencriptar(obj.contrasenia,TokenEncriptacion));
            email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };
            _correo.enviarCorreo(email, smtp);
            return result;
        }

        public string getContraseniaByIdUser(in int id)
        {
            return _unitOfWork.IAccesos.getContraseniaByIdUser(id);
        }
    }
}
