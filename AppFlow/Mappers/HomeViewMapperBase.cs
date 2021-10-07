using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFlow.Models;
using AppFlow.CommonInterface;
using AppFlow.CommonClass.Grid;
using AppFlow.CommonConfiguration.FieldMetaProvider;

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
                    x=> _rowMapper.Map(new HomeRowMapping(x, source.meta, source.link))
                );
            return new GridDataResult<IEnumerable<GridResultRow<GridResultCell>>>(gridRow);
        }
        

        public HomeActionUrl links()
        {
            return new HomeActionUrl();
        }
    }

    public class HomeActionUrl
    {
        public string Update { get; }
        public string Delete { get; }

        public HomeActionUrl()
        {
            Update = "UpdateUrl";
            Delete = "DeleteUrl";
        }
    }


    public class HomeViewMapping
    {
        public IEnumerable<HomeModel> source { get; }
        public Dictionary<string, FieldDefinition> meta { get; }
        public HomeActionUrl link { get; }
        public HomeViewMapping(
                IEnumerable<HomeModel> _source,
                Dictionary<string, FieldDefinition> _meta,
                HomeActionUrl _link
            )
        {
            source = _source;
            meta = _meta;
            link = _link;
        }
    }
}
