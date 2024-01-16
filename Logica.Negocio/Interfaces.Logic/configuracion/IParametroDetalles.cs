using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Negocio.Interfaces.Logic.configuracion
{
    public interface IParametroDetalles
    {
        bool Update(t_parametroDetalles obj);
        int Insert(t_parametroDetalles obj);
        IEnumerable<t_parametroDetalles> GetList();
        t_parametroDetalles GetById(int id);
    }
}
