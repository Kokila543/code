using Endpoints_Creation.Models;

namespace Endpoints_Creation.Services.Interfaces
{
    public interface ITagAssociationsValidationService
    {
        Task<string> CheckCommonValidations(TagAssociationsDto dto);
        Task<string> CheckDemandValidations(TagAssociationsDto dto);
        Task<string> CheckResourceValidations(TagAssociationsDto dto);
        Task<string> CheckRemovalValidations(TagAssociationsDto dto);
    }
}
