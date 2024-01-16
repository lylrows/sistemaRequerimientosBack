using Modelos.Datos.Mapeo.Base.Datos.mejora;
using Repositorios.Interfaces.mejoras;

namespace Acceso.Datos.Implementacion.Repositorios.mejora
{
    public class mejoraAsignacionesRepository : Repository<t_mejoraAsignaciones>, IMejoraAsignacionesRepository
    {
        public mejoraAsignacionesRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}
