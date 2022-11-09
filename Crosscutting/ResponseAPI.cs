namespace CalculoCDB.Crosscutting
{
    public class ResponseAPI<TResponseType> : ResponseAPI
    {
        public TResponseType Content { get; set; }
    }

    public class ResponseAPI
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; }
        public string Exception { get; set; }
    }
}
