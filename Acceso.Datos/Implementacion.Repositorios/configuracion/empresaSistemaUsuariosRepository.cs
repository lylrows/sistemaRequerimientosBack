using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;
using Repositorios.Interfaces.configuracion;

namespace Acceso.Datos.Implementacion.Repositorios.configuracion
{
    public class empresaSistemaUsuariosRepository:Repository<t_empresaSistemaUsuarios>,IEmpresaSistemaUsuariosRepository
    {
        public empresaSistemaUsuariosRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}
