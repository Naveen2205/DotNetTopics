using Microsoft.AspNetCore.Mvc;
using AppFlow.Services;
using AppFlow.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppFlow.DTO;
using AppFlow.MetaProvider;
using AppFlow.CommonInterface;
using AppFlow.Mappers;
using AppFlow.CommonClass.Grid;

namespace AppFlow.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] SearchParameter searchParameter)
        {
            IEnumerable<HomeModel> source = await _homeService.GetAll(searchParameter);
            HomeMetaProvider meta = new HomeMetaProvider();
            HomeActionUrl url = new HomeActionUrl();
            return Ok(_viewMapper.Map(new HomeViewMapping(source, meta.Fields, url)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HomeModel body)
        {
            var getData = await _homeService.Create(body);
            HomeMetaProvider meta = new HomeMetaProvider();
            HomeActionUrl url = new HomeActionUrl();
            return Ok(_rowMapper.Map(new HomeRowMapping(body, meta.Fields, url)));
        }

        [HttpPost("/home/update/{filter}")]
        public async Task<IActionResult> UpdateById(string filter, [FromBody] HomeModel body)
        {
            var getUpdatedData = await _homeService.UpdateById(filter, body);
            HomeMetaProvider meta = new HomeMetaProvider();
            HomeActionUrl url = new HomeActionUrl();
            return Ok(_rowMapper.Map(new HomeRowMapping(body, meta.Fields, url)));
        }

        [HttpPost("home/delete/{filter}")]
        public async Task<IActionResult> DeleteById(string filter)
        {
            var getData = await _homeService.DeleteById(filter);
            return NoContent();
        }
    }
}
