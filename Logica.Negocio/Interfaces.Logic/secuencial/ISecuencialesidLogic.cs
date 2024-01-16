using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.secuencial;

namespace Logica.Negocio.Interfaces.Logic.secuencial
{
    public interface ISecuencialesidLogic
    {
        bool Update(secuencialesId obj);
        int Insert(secuencialesId obj);
        IEnumerable<secuencialesId> GetList();
        secuencialesId GetById(int id);
        bool Delete(secuencialesId obj);
    }
}