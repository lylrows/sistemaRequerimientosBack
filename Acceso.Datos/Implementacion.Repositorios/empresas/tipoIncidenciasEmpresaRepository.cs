using Modelos.Datos.Mapeo.Base.Datos.empresas;
using Repositorios.Interfaces.empresas;

namespace Acceso.Datos.Implementacion.Repositorios.empresas
{
    public class tipoIncidenciasEmpresaRepository : Repository<tipoIncidenciasEmpresa>, ITipoincidenciasempresaRepository
    {
        public tipoIncidenciasEmpresaRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}