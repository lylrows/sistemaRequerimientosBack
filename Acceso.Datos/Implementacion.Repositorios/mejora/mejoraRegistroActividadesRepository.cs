using Modelos.Datos.Mapeo.Base.Datos.mejora;
using Repositorios.Interfaces.mejoras;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acceso.Datos.Implementacion.Repositorios.mejora
{
    public class mejoraRegistroActividadesRepository : Repository<t_mejoraRegistroActividades>, IMejoraRegistroActividadesRepository
    {
        public mejoraRegistroActividadesRepository(string _connectionString) : base(_connectionString)
        {

        }
    }
}
