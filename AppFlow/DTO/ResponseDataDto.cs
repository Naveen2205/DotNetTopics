namespace AppFlow.DTO
{
    public class ResponseDataDto<TModel>
    {
        private TModel DataModel { get; }

        public ResponseDataDto(
                TModel dataModel
            )
        {
            DataModel = dataModel;
        }
    }
}