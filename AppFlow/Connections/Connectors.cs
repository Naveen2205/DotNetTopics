using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AppFlow.Connections
{
    public interface IConnectors
    {
        public IDbConnection AppFlowConnector();
    }
    public class Connectors : IConnectors
    {
        private readonly IConfiguration _config;
        public Connectors(
                IConfiguration config
            )
        {
            _config = config;
        }
        public IDbConnection AppFlowConnector()
        {
            return new SqlConnection(_config.GetConnectionString("mssqlConnector"));
        }
    }
}
