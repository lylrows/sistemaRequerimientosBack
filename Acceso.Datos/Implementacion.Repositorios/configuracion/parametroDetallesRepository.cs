using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;
using Repositorios.Interfaces.configuracion;


namespace Acceso.Datos.Implementacion.Repositorios.configuracion
{
    public class parametroDetallesRepository : Repository<t_parametroDetalles>, IParametroDetallesRepository
    {
        public parametroDetallesRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}
