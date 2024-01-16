using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Repositorios.Interfaces.incidencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acceso.Datos.Implementacion.Repositorios.incidencia
{
    public class tagsRepository : Repository<tags>, ITagsRepository
    {
        public tagsRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}
