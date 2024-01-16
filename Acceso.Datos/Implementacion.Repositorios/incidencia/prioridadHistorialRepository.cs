using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Repositorios.Interfaces.incidencia;

namespace Acceso.Datos.Implementacion.Repositorios.incidencia
{
    public class prioridadHistorialRepository : Repository<prioridadHistorial>, IPrioridadhistorialRepository
    {
        public prioridadHistorialRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}