namespace Endpoints_Creation.Models
{
    public class ResultModel
    {
        public string Message { get; set; }
        public IEnumerable<TagMasterDto> TagMasterDtoList { get; set; }
    }
}
