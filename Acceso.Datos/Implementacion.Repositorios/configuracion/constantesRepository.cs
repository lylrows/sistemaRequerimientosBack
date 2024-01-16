﻿using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;
using Repositorios.Interfaces.configuracion;

namespace Acceso.Datos.Implementacion.Repositorios.configuracion
{
    public class constantesRepository : Repository<t_constantes>, IConstantesRepository
    {
        public constantesRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}
