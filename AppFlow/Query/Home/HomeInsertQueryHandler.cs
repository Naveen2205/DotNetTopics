using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFlow.CommonInterface;
using AppFlow.Models;
using AppFlow.Connections;
using Dapper;

namespace AppFlow.Query
{
    public class HomeInsertQueryHandler : IQueryHandler<HomeCreateQuery, IEnumerable<HomeModel>>
    {
        private readonly IConnectors _connector;
        public HomeInsertQueryHandler(
                IConnectors connector
            )
        {
            _connector = connector;
        }
        public async Task<IEnumerable<HomeModel>> Handle(HomeCreateQuery data)
        {
            return await Query(data);
        }

        public async Task<IEnumerable<HomeModel>> Query(HomeCreateQuery data)
        {
            string insertQuery = $@"
                INSERT INTO [dbo].[Home] (firstname, lastname, dob, gender, city, country) values (@firstname, @lastname, @dob, @gender, @city, @country)
";
            IEnumerable<HomeModel> dataModel = await _connector.AppFlowConnector().QueryAsync<HomeModel>(insertQuery, data);
            return dataModel;
        }
    }

    public class HomeCreateQuery
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Dob { get; }
        public string Gender { get; }
        public string City { get; }
        public string Country { get; }
        public HomeCreateQuery(
                HomeModel model
            )
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            Dob = model.Dob;
            Gender = model.Gender;
            City = model.City;
            Country = model.Country;
        }
    }
}
