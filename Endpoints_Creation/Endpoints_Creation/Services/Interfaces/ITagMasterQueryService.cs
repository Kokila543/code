using Endpoints_Creation.Models;

namespace Endpoints_Creation.Services.Interfaces
{
    public interface ITagMasterQueryService
    {
        Task<int?> GetResourceId(TagAssociationsDto dto);
        Task<IEnumerable<TagMasterDto>> GetTagDropdownList(
            TagAssociationsDto dto);
    }
}
