using Endpoints_Creation.Models;
using Endpoints_Creation.Services.Interfaces;

namespace Endpoints_Creation.Services.Implementations
{
    public class TagMasterQueryService : ITagMasterQueryService
    {
        public Task<int?> GetResourceId(TagAssociationsDto dto)
        {
            return Task.FromResult<int?>(123); // Mocked
        }
        public Task<IEnumerable<TagMasterDto>> GetTagDropdownList(
           TagAssociationsDto dto)
        {
            var list = new List<TagMasterDto>
            {
                new TagMasterDto { TagId = 1, TagName = "Cloud" },
                new TagMasterDto { TagId = 2, TagName = "DevOps" },
                new TagMasterDto { TagId = 3, TagName = "AI" }
            };

            return Task.FromResult<IEnumerable<TagMasterDto>>(list);
        }
    }
}

