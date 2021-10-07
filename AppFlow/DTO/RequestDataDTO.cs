using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFlow.DTO
{
    public class RequestDataDto<TModel>
    {
        public TModel DataModel { get; set; }
    }
}
