using Modelos.Datos.Mapeo.Base.Datos.secuencial;
using Repositorios.Interfaces.secuencial;

namespace Acceso.Datos.Implementacion.Repositorios.secuencial
{
    public class secuencialesIdRepository : Repository<secuencialesId>, ISecuencialesidRepository
    {
        public secuencialesIdRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}