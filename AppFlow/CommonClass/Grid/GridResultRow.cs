using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFlow.Mappers;
using AppFlow.CommonClass.Grid;
using AppFlow.Api.MVC.Models;

namespace AppFlow.CommonClass.Grid
{
    public class GridResultRow<TCell>
    {
        public IEnumerable<TCell> Row { get; }
        public IEnumerable<Link> Url { get; }
        public GridResultRow(
                IEnumerable<TCell> _row,
                IEnumerable<Link> _url
            )
        {
            Row = _row;
            Url = _url;
        }
    }
}
