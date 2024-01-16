using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Repositorios.Interfaces.incidencia;

namespace Acceso.Datos.Implementacion.Repositorios.incidencia
{
    public class incidenciasHistorialRepository : Repository<incidenciasHistorial>, IIncidenciashistorialRepository
    {
        public incidenciasHistorialRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}