namespace Endpoints_Creation
{
    public class TagMasterInputModel
    {
        public string TagName { get; set; }
        public string TagAction { get; set; } // Add / Remove
        public int? TagId { get; set; }
    }
}
