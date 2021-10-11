using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppFlow.Api.CommonInterface.IHandlers;

namespace AppFlow.Query
{
    public class AbstractQueryHandler<TModel>
    {
        public virtual Task<IEnumerable<TModel>> Handle<TParamModel>()
        {
            return null;
        }

        public virtual Task<IEnumerable<TModel>> Query<TParamModel>()
        {
            return null;
        }
    }
}