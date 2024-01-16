using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Negocio.Interfaces.Logic.configuracion
{
    public interface IMuralLogic
    {
        bool Update(mural obj);
        int Insert(mural obj);
        IEnumerable<mural> GetList();
        mural GetById(int id);
        bool Delete(mural obj);
    }
}
