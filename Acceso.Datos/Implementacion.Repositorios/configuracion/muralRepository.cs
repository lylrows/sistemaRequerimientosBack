using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Repositorios.Interfaces.configuracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acceso.Datos.Implementacion.Repositorios.configuracion
{
    public class muralRepository : Repository<mural>, IMuralRepository
    {
        public muralRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}
