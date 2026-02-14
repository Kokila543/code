using Endpoints_Creation.Models;

namespace Endpoints_Creation.Services.Interfaces
{
    public interface ITagMasterValidationService
    {
        Task<string> CheckTagMasterAdditionValidation(TagMasterDto dto);
        Task<string> CheckTagMasterRemovalValidation(TagMasterDto dto);
    }
}
