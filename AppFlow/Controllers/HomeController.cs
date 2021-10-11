using Microsoft.AspNetCore.Mvc;
using AppFlow.Services;
using AppFlow.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AppFlow.DTO;
using AppFlow.MetaProvider;
using AppFlow.Api.CommonInterface.IHandlers;
using AppFlow.Mappers;
using AppFlow.CommonClass.Grid;
using AppFlow.Api.MVC.Models;
using AppFlow.Api.MVC.Routing;

namespace AppFlow.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IMappingHandler<HomeViewMapping, GridDataResult<IEnumerable<GridResultRow<GridResultCell>>>> _viewMapper;
        private readonly IMappingHandler<HomeRowMapping, GridResultRow<GridResultCell>> _rowMapper;
        private readonly IHomeService _homeService;
        public HomeController(
                IMappingHandler<HomeViewMapping, GridDataResult<IEnumerable<GridResultRow<GridResultCell>>>> viewMapper,
                IMappingHandler<HomeRowMapping, GridResultRow<GridResultCell>> rowMapper,
                IHomeService homeService
            )
        {
            _viewMapper = viewMapper;
            _homeService = homeService;
            _rowMapper = rowMapper;
        }

        [HttpGet("", Name = ApiRoutes.HomeRoutes.INDEX)]
        public GridAction Index()
        {
            var actions = new GridAction().Add(
                    new[]
                    {
                        new Link("Data", Url.Link(ApiRoutes.HomeRoutes.DATA, null)),
                        new Link("Add", Url.Link(ApiRoutes.HomeRoutes.ADD, null)),
                        new Link("Edit", Url.Link(ApiRoutes.HomeRoutes.EDIT, null)),
                        new Link("Bulk_Edit", Url.Link(ApiRoutes.HomeRoutes.BULK_EDIT, null)),
                        new Link("Bulk_Edit_All", Url.Link(ApiRoutes.HomeRoutes.BULK_EDIT_ALL, null)),
                        new Link("Delete", Url.Link(ApiRoutes.HomeRoutes.DELETE, null)),
                        new Link("Bulk_Delete", Url.Link(ApiRoutes.HomeRoutes.BULk_DELETE, null)),
                        new Link("Bulk_Delete_All", Url.Link(ApiRoutes.HomeRoutes.BULK_DELETE_ALL, null)),
                        new Link("Export", Url.Link(ApiRoutes.HomeRoutes.EXPORT, null)),
                        new Link("Export_All", Url.Link(ApiRoutes.HomeRoutes.EXPORT_ALL, null)),
                        new Link("Import", Url.Link(ApiRoutes.HomeRoutes.IMPORT, null))
                    }
                );
            return actions;
        }

        [HttpPost("Data", Name = ApiRoutes.HomeRoutes.DATA)]
        public async Task<IActionResult> Data([FromBody] SearchParameter searchParameter)
        {
            IEnumerable<HomeModel> source = await _homeService.GetAll(searchParameter);
            HomeMetaProvider meta = new HomeMetaProvider();
            return Ok(_viewMapper.Map(new HomeViewMapping(source, meta.Fields, Url)));
        }

        [HttpPost("Add", Name = ApiRoutes.HomeRoutes.ADD)]
        public async Task<IActionResult> Create([FromBody] HomeModel body)
        {
            var getData = await _homeService.Create(body);
            HomeMetaProvider meta = new HomeMetaProvider();
            return Ok(_rowMapper.Map(new HomeRowMapping(body, meta.Fields, Url)));
        }

        [HttpPost("home/update/{filter}", Name = ApiRoutes.HomeRoutes.EDIT)]
        public async Task<IActionResult> UpdateById(string filter, [FromBody] HomeModel body)
        {
            var getUpdatedData = await _homeService.UpdateById(filter, body);
            HomeMetaProvider meta = new HomeMetaProvider();
            return Ok(_rowMapper.Map(new HomeRowMapping(body, meta.Fields, Url)));
        }

        [HttpPost("home/delete/{filter}", Name = ApiRoutes.HomeRoutes.DELETE)]
        public async Task<IActionResult> DeleteById(string filter)
        {
            var getData = await _homeService.DeleteById(filter);
            return NoContent();
        }
    }
}
