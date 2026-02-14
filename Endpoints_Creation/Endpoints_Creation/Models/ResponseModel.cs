namespace Endpoints_Creation.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public bool Success => string.IsNullOrEmpty(Message);
    }
}
