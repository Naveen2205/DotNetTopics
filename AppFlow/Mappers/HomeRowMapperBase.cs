using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFlow.CommonInterface;
using AppFlow.CommonClass.Grid;
using AppFlow.Models;
using AppFlow.CommonConfiguration.FieldMetaProvider;
using AppFlow.Columns;

namespace AppFlow.Mappers
{
    public class HomeRowMapperBase : IMappingHandler<HomeRowMapping, GridResultRow<GridResultCell>>
    {
        public GridResultRow<GridResultCell> Map(HomeRowMapping source)
        {
            IEnumerable<GridResultCell> sourceData = source.meta.Select(
                    x => HandleColumn(x, source.source)
                 );
            return new GridResultRow<GridResultCell>(sourceData, source.link);
        }

        public GridResultCell HandleColumn(KeyValuePair<string, FieldDefinition> meta, HomeModel source)
        {
            switch (meta.Key)
            {
                case HomeColumn.FirstName:
                    return new GridResultCell(meta.Key, source.FirstName, meta.Value);
                case HomeColumn.LastName:
                    return new GridResultCell(meta.Key, source.LastName, meta.Value);
                case HomeColumn.DOB:
                    return new GridResultCell(meta.Key, source.Dob, meta.Value);
                case HomeColumn.Gender:
                    return new GridResultCell(meta.Key, source.Gender, meta.Value);
                case HomeColumn.City:
                    return new GridResultCell(meta.Key, source.City, meta.Value);
                case HomeColumn.Country:
                    return new GridResultCell(meta.Key, source.Country, meta.Value);
                default:
                    return new GridResultCell("Error", "Error in mapping", null);
            }
        }
    }

    public class HomeRowMapping
    {
        public HomeModel source { get; }
        public IDictionary<string, FieldDefinition> meta { get; }
        public HomeActionUrl link { get; }
        public HomeRowMapping(
                HomeModel _source,
                IDictionary<string, FieldDefinition> _meta,
                HomeActionUrl _link
            )
        {
            source = _source;
            meta = _meta;
            link = _link;
        }
    }
}
