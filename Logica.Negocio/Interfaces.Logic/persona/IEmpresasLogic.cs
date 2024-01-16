using System;
using System.Collections.Generic;
using System.Text;
using Modelos.Datos.Mapeo.Base.Datos.persona;

namespace Logica.Negocio.Interfaces.Logic.persona
{
    public interface IEmpresasLogic
    {
        bool Update(t_empresa obj);
        int Insert(t_empresa obj);
        IEnumerable<t_empresa> GetList();
        t_empresa GetById(int id);
        IEnumerable<t_empresa> getEmpresaByIdUsuario(in int id);
    }
}
