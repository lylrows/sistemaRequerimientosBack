using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Negocio.Interfaces.Logic.incidencia
{
    public interface ITagsLogic
    {
        bool Update(tags obj);
        int Insert(tags obj);
        IEnumerable<tags> GetList();
        tags GetById(int id);
        bool Delete(tags obj);
    }
}
