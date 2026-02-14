using Endpoints_Creation.Models;
using Endpoints_Creation.Services.Interfaces;

namespace Endpoints_Creation.Services.Implementations
{
    public class TagMasterValidationService : ITagMasterValidationService
    {
        public Task<string> CheckTagMasterAdditionValidation(TagMasterDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TagName))
                return Task.FromResult("Tag Name is required.");

            return Task.FromResult(string.Empty);
        }

        public Task<string> CheckTagMasterRemovalValidation(TagMasterDto dto)
        {
            if (dto.TagId == null)
                return Task.FromResult("TagId is required for removal.");

            return Task.FromResult(string.Empty);
        }

    }
}
