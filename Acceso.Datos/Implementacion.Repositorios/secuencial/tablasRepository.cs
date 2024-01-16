using Modelos.Datos.Mapeo.Base.Datos.secuencial;
using Repositorios.Interfaces.secuencial;

namespace Acceso.Datos.Implementacion.Repositorios.secuencial
{
    public class tablasRepository : Repository<tablas>, ITablasRepository
    {
        public tablasRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}