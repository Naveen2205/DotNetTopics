using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFlow.Mappers;
using AppFlow.CommonClass.Grid;

namespace AppFlow.CommonClass.Grid
{
    public class GridResultRow<TCell>
    {
        public IEnumerable<TCell> Row { get; }
        public HomeActionUrl Url { get; }
        public GridResultRow(
                IEnumerable<TCell> _row,
                HomeActionUrl _url
            )
        {
            Row = _row;
            Url = _url;
        }
    }
}
