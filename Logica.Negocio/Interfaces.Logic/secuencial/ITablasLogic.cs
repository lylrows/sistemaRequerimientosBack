using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.secuencial;

namespace Logica.Negocio.Interfaces.Logic.secuencial
{
    public interface ITablasLogic
    {
        bool Update(tablas obj);
        int Insert(tablas obj);
        IEnumerable<tablas> GetList();
        tablas GetById(int id);
        bool Delete(tablas obj);
    }
}