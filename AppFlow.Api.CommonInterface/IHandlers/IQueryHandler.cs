using System.Threading.Tasks;

namespace AppFlow.Api.CommonInterface.IHandlers
{
    public interface IQueryHandler<TSource, TTarget>
    {
        Task<TTarget> Handle(TSource model); 
        Task<TTarget> Query(TSource model);
    }
}
