using Modelos.Datos.Mapeo.Base.Datos.mejora;
using Repositorios.Interfaces.mejoras;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acceso.Datos.Implementacion.Repositorios.mejora
{
    
    public class mejoraArchivosRepository : Repository<t_mejoraArchivos>, IMejoraArchivosRepository
    {
        public mejoraArchivosRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}
