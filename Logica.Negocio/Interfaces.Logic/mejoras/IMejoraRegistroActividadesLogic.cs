using Modelos.Datos.Mapeo.Base.Datos.mejora;
using System.Collections.Generic;
using System.Text;

namespace Logica.Negocio.Interfaces.Logic.mejoras
{
    public interface IMejoraRegistroActividadesLogic
    {
        bool Update(t_mejoraRegistroActividades obj);
        int Insert(t_mejoraRegistroActividades obj);
        IEnumerable<t_mejoraRegistroActividades> GetList();
        t_mejoraRegistroActividades GetById(int id);
        bool Delete(t_mejoraRegistroActividades obj);
    }
}
