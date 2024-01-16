using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Negocio.Interfaces.Logic.configuracion
{
    public interface IParametrosLogic
    {
        bool Update(t_parametros obj);
        int Insert(t_parametros obj);
        IEnumerable<t_parametros> GetList();
        t_parametros GetById(int id);
    }
}
