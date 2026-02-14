namespace Endpoints_Creation.Models
{
    public class TagMasterDto
    {
        public int TagId { get; set; }
        public string TagName
        { get; set; }
        
        }
    public class TagMasterDtos
    {
        public string taSource { get; set; }
        public string tagAssociationsRefEntity
        { get; set; }
        public long tagAssociationsRefEntityKey { get; set; }

    }
}
