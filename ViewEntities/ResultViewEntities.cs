namespace ProdManager.ViewEntities
{
    public class ResultViewEntities<T>
    {
        public T? Data { get; private set; }
        public List<string> Errors { get; private set; } = new();
        
        public ResultViewEntities(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ResultViewEntities(T data)
        {
            Data = data;
        }

        public ResultViewEntities(List<string> errors)
        {
            Errors = errors;
        }

        public ResultViewEntities(string error)
        {
            Errors.Add(error);
        }

        
    }
}
