using System;
using System.Collections.Generic;
using System.Text;
using Modelos.Datos.Mapeo.Base.Datos.correo;
using Modelos.Datos.Mapeo.Base.Datos.persona;

namespace Logica.Negocio.Interfaces.Logic.persona
{
    public interface IAccesosLogic
    {
        bool Update(accesos obj);
        int Insert(accesos obj);
        IEnumerable<accesos> GetList();
        accesos GetById(int id);
        bool Delete(accesos obj);
        ResultadoEnvio generadorCodigo(string usuario);
        bool validarCodigo(int codigo, string usuario);
        bool actualizaContrasenia(string contrasenia, string usuario);
        string getContraseniaByIdUser(in int id);
    }
}
