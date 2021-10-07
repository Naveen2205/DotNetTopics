using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFlow.CommonClass.Grid
{
    public class GridDataResult<TMeta>
    {
        public TMeta source { get; }
        public GridDataResult(
                TMeta _source
            )
        {
            source = _source;
        }
    }
}
