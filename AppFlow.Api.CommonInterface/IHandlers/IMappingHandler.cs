namespace AppFlow.Api.CommonInterface.IHandlers
{
    public interface IMappingHandler<TSouce, TTarget>
    {
        public TTarget Map(TSouce source);
    }
}