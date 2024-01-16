using Modelos.Datos.Mapeo.Base.Datos.mejora;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Negocio.Interfaces.Logic.mejoras
{
    public interface IMejoraArchivosLogic
    {
        bool Update(t_mejoraArchivos obj);
        int Insert(t_mejoraArchivos obj);
        IEnumerable<t_mejoraArchivos> GetList();
        t_mejoraArchivos GetById(int id);
        bool Delete(t_mejoraArchivos obj);
    }
}
