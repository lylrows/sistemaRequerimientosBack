using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using Modelos.Datos.Mapeo.Base.Datos.persona;

namespace Repositorios.Interfaces.persona
{
    public interface IAccesosRepository : IRepository<accesos>
    {
        int generadorCodigo(string usuario);
        //ResultadoEnvio enviarCorreo(string usuario, int codigo, DatosEmail email, DatosSMTP smtp);
        bool validarCodigo(int codigo, string usuario);
        bool actualizaContrasenia(string contrasenia, string usuario);
        string getContraseniaByIdUser(in int id);
    }
}
