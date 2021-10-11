using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFlow.Api.CommonInterface.IHandlers;
using AppFlow.Models;
using AppFlow.DTO;
using AppFlow.Connections;
using Dapper;

namespace AppFlow.Query.Home
{
    public class HomeUpdateQueryHandler : IQueryHandler<HomeUpdateQuery, IEnumerable<HomeModel>>
    {
        private readonly IConnectors _connector;
        public HomeUpdateQueryHandler(
                IConnectors connector
            )
        {
            _connector = connector;
        }
        public async Task<IEnumerable<HomeModel>> Handle(HomeUpdateQuery filter)
        {
            return await Query(filter);
        }

        public async Task<IEnumerable<HomeModel>> Query(HomeUpdateQuery filter)
        {
            string query = $@"UPDATE [dbo].[Home] set lastname = @lastname where firstname = @firstname";
            IEnumerable<HomeModel> updatedData = await _connector.AppFlowConnector().QueryAsync<HomeModel>(query, new { firstname = filter._searchParameter, lastname = filter.LastName }); ;
            return updatedData;
        }
    }

    public class HomeUpdateQuery
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Dob { get; }
        public string Gender { get; }
        public string City { get; }
        public string Country { get; }
        public string _searchParameter { get; }
        public HomeUpdateQuery(
                string searchParameter,
                HomeModel data
            )
        {
            _searchParameter = searchParameter;
            FirstName = data.FirstName ?? null;
            LastName = data.LastName ?? null;
            Dob = data.Dob ?? null;
            Gender = data.Gender ?? null;
            City = data.City ?? null;
            Country = data.Country ?? null;
        }
    }
}
