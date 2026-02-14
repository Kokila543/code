namespace Endpoints_Creation.Models
{
    public class TagAssociationsDto
    {
        public string TASource { get; set; }
        public string TagAssociationsSource { get; set; }
        public string TagAssociationsRefEntity { get; set; }
        public int? TagAssociationsRefEntityKey { get; set; }
        public string ResourcePersonnelNumber { get; set; }
    }
    public class TagAssociationRequestDto
    {
        public string TaSource { get; set; }
        public string TagAssociationsRefEntity { get; set; }
        public long TagAssociationsRefEntityKey { get; set; }
    }

}
