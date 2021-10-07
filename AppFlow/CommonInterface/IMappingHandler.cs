using AppFlow.DTO;

namespace AppFlow.CommonInterface
{
    public interface IMappingHandler<TSouce, TTarget>
    {
        //public ResponseDataDto<TModel> SendResponse<TModel>(TModel data);
        public TTarget Map(TSouce source);
    }
}