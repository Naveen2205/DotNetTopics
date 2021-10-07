using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFlow.CommonInterface;
using AppFlow.Models;
using AppFlow.Connections;
using Dapper;

namespace AppFlow.Query.Home
{
    public class HomeDeleteQueryHandler : IQueryHandler<HomeDeleteQuery, IEnumerable<HomeModel>>
    {
        private readonly IConnectors _connector;
        public HomeDeleteQueryHandler(
                IConnectors connector
            )
        {
            _connector = connector;
        }
        public async Task<IEnumerable<HomeModel>> Handle(HomeDeleteQuery filter)
        {
            return await Query(filter);
        }

        public async Task<IEnumerable<HomeModel>> Query(HomeDeleteQuery filter)
        {
            string query = $@"DELETE FROM [dbo].[Home] where firstname = @firstname";
            IEnumerable<HomeModel> data = await _connector.AppFlowConnector().QueryAsync<HomeModel>(query, new { firstname = filter.FirstName });
            return data;
        }
    }

    public class HomeDeleteQuery
    {
        public string FirstName { get; }
        public HomeDeleteQuery(
                string firstName
            )
        {
            FirstName = firstName;
        }
    }
}
