using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFlow.CommonInterface
{
    public interface IQueryHandler<TSource, TTarget>
    {
        Task<TTarget> Handle(TSource model); 
        Task<TTarget> Query(TSource model);
    }
}
