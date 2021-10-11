using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFlow.Api.CommonInterface.IHandlers;
using AppFlow.CommonClass.Grid;
using AppFlow.Api.MVC.Models;
using AppFlow.Api.MVC.Routing;
using AppFlow.Models;
using AppFlow.CommonConfiguration.FieldMetaProvider;
using AppFlow.Columns;
using Microsoft.AspNetCore.Mvc;

namespace AppFlow.Mappers
{
    public class HomeRowMapperBase : IMappingHandler<HomeRowMapping, GridResultRow<GridResultCell>>
    {
        public HomeRowMapperBase(
            )
        {
        }
        public GridResultRow<GridResultCell> Map(HomeRowMapping source)
        {
            IEnumerable<GridResultCell> sourceData = source.meta.Select(
                    x => HandleColumn(x, source.source)
                 );
            return new GridResultRow<GridResultCell>(sourceData, BuildLinks(source.urlHelper));
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

        public IEnumerable<Link> BuildLinks(IUrlHelper urlHelper)
        {
            yield return new Link("Edit", urlHelper.Link(ApiRoutes.HomeRoutes.EDIT, null));
            yield return new Link("Delete", urlHelper.Link(ApiRoutes.HomeRoutes.DELETE, null));
            yield return new Link("Close", urlHelper.Link(ApiRoutes.HomeRoutes.CLOSE, null));
            yield return new Link("Previous", urlHelper.Link(ApiRoutes.HomeRoutes.PREVIOUS, null));
        }
    }

    public class HomeRowMapping
    {
        public HomeModel source { get; }
        public IDictionary<string, FieldDefinition> meta { get; }
        public IUrlHelper urlHelper { get; }
        public HomeRowMapping(
                HomeModel _source,
                IDictionary<string, FieldDefinition> _meta,
                IUrlHelper _urlHelper
            )
        {
            source = _source;
            meta = _meta;
            urlHelper = _urlHelper;
        }
    }
}
