using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFlow.CommonInterface;
using AppFlow.Query;
using AppFlow.Connections;
using AppFlow.Models;
using Dapper;
using AppFlow.DTO;
using AppFlow.Redis;

namespace AppFlow.Query.Home
{
    public class HomeFetchQueryHandler : IQueryHandler<HomeFetchQuery, IEnumerable<HomeModel>>
    {
        private readonly IConnectors _connector;
        private readonly IRedisCacheService _redisCache;
        public HomeFetchQueryHandler(
                IConnectors connectors,
                IRedisCacheService redisCache
            )
        {
            _connector = connectors;
            _redisCache = redisCache;
        }
        public async Task<IEnumerable<HomeModel>> Handle(HomeFetchQuery filter)
        {
            byte[] cachedData = await _redisCache.GetCachedData("HOME_GET_ALL");
            if(cachedData != null)
            {
                
                return _redisCache.DeserializeData(cachedData);
            }
            else
            {
                return await Query(filter);
            }
        }
        public async Task<IEnumerable<HomeModel>> Query(HomeFetchQuery filter)
        {
            IEnumerable<HomeModel> dataList;
            string fetchQuery = $@"SELECT * FROM [dbo].[Home]";
            if(filter._searchParameter != null)
            {
                fetchQuery += "where [firstname] = @firstname";
                dataList = await _connector.AppFlowConnector().QueryAsync<HomeModel>(fetchQuery, new { firstname =  filter._searchParameter.Filter});
                return dataList;
            }
            dataList = await _connector.AppFlowConnector().QueryAsync<HomeModel>(fetchQuery);
            await _redisCache.SerializeData(dataList, "HOME_GET_ALL");
            return dataList;
        }
    }

    public class HomeFetchQuery
    {
        public SearchParameter _searchParameter { get; }
        public HomeFetchQuery(
                SearchParameter searchParameter
            )
        {
            _searchParameter = searchParameter ?? null;
        }
    }
}
