using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFlow.Models;
using AppFlow.Api.CommonInterface.IHandlers;
using AppFlow.CommonClass.Grid;
using AppFlow.CommonConfiguration.FieldMetaProvider;
using Microsoft.AspNetCore.Mvc;

namespace AppFlow.Mappers
{
    public class HomeViewMapperBase : IMappingHandler<HomeViewMapping, GridDataResult<IEnumerable<GridResultRow<GridResultCell>>>>
    {
        private readonly IMappingHandler<HomeRowMapping, GridResultRow<GridResultCell>> _rowMapper;
        public HomeViewMapperBase(
                IMappingHandler<HomeRowMapping, GridResultRow<GridResultCell>> rowMapper
            )
        {
            _rowMapper = rowMapper;
        }
        public GridDataResult<IEnumerable<GridResultRow<GridResultCell>>> Map(HomeViewMapping source)
        {
            IEnumerable<GridResultRow<GridResultCell>> gridRow = source.source.Select(
                    x=> _rowMapper.Map(new HomeRowMapping(x, source.meta, source.urlHelper))
                );
            return new GridDataResult<IEnumerable<GridResultRow<GridResultCell>>>(gridRow);
        }
    }


    public class HomeViewMapping
    {
        public IEnumerable<HomeModel> source { get; }
        public Dictionary<string, FieldDefinition> meta { get; }
        public IUrlHelper urlHelper { get; }
        public HomeViewMapping(
                IEnumerable<HomeModel> _source,
                Dictionary<string, FieldDefinition> _meta,
                IUrlHelper _urlHelper
            )
        {
            source = _source;
            meta = _meta;
            urlHelper = _urlHelper;
        }
    }
}
