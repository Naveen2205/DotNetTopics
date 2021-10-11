using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AppFlow.Models;
using System.Data;
using AppFlow.Api.CommonInterface.IHandlers;
using AppFlow.DTO;
using AppFlow.Query;
using AppFlow.Query.Home;
using Microsoft.AspNetCore.Mvc;
using AppFlow.Connections;

namespace AppFlow.Services
{
    public interface IHomeService
    {
        public Task<IEnumerable<HomeModel>> GetAll(SearchParameter searchParamter);
        public Task<IEnumerable<HomeModel>> Create(HomeModel body);
        public Task<IEnumerable<HomeModel>> UpdateById(string filter, HomeModel body);
        public Task<IEnumerable<HomeModel>> DeleteById(string filter);
    }
    public class HomeService : IHomeService
    {
        private readonly IQueryHandler<HomeFetchQuery, IEnumerable<HomeModel>> _fetchQueryHandler;
        private readonly IQueryHandler<HomeCreateQuery, IEnumerable<HomeModel>> _insertQueryHandler;
        private readonly IQueryHandler<HomeUpdateQuery, IEnumerable<HomeModel>> _updateQueryHandler;
        private readonly IQueryHandler<HomeDeleteQuery, IEnumerable<HomeModel>> _deleteQueryHandler;
        public HomeService(
                IQueryHandler<HomeFetchQuery, IEnumerable<HomeModel>> fetchQueryHandler,
                IQueryHandler<HomeCreateQuery, IEnumerable<HomeModel>> insertQueryHandler,
                IQueryHandler<HomeUpdateQuery, IEnumerable<HomeModel>> updateQueryHandler,
                IQueryHandler<HomeDeleteQuery, IEnumerable<HomeModel>> deleteQueryHandler
                    )
        {
            _fetchQueryHandler = fetchQueryHandler;
            _insertQueryHandler = insertQueryHandler;
            _updateQueryHandler = updateQueryHandler;
            _deleteQueryHandler = deleteQueryHandler;
        }
        public async Task<IEnumerable<HomeModel>> GetAll(SearchParameter searchParameter)
        {
            IEnumerable<HomeModel> detailList = await _fetchQueryHandler.Handle(new HomeFetchQuery(searchParameter));
            return detailList;
        }
        public async Task<IEnumerable<HomeModel>> Create(HomeModel body)
        {
            IEnumerable<HomeModel> create = await _insertQueryHandler.Handle(new HomeCreateQuery(body));
            return create;
        }

        public async Task<IEnumerable<HomeModel>> UpdateById(string Filter, [FromBody] HomeModel body)
        {
            IEnumerable<HomeModel> updatedData = await _updateQueryHandler.Handle(new HomeUpdateQuery(Filter, body));
            return updatedData;
        }

        public async Task<IEnumerable<HomeModel>> DeleteById(string Filter)
        {
            IEnumerable<HomeModel> deleteData = await _deleteQueryHandler.Handle(new HomeDeleteQuery(Filter));
            return deleteData;
        }
    }
}
