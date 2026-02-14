using Endpoints_Creation.Models;
using Endpoints_Creation.Services.Interfaces;

namespace Endpoints_Creation.Services.Implementations
{
    public class TagAssociationsValidationService : ITagAssociationsValidationService
    {
        public Task<string> CheckCommonValidations(TagAssociationsDto dto)
            => Task.FromResult(string.Empty);

        public Task<string> CheckDemandValidations(TagAssociationsDto dto)
            => Task.FromResult(string.Empty);

        public Task<string> CheckResourceValidations(TagAssociationsDto dto)
            => Task.FromResult(string.Empty);
        public Task<string> CheckRemovalValidations(TagAssociationsDto dto)
        {
            return Task.FromResult(string.Empty);
        }
    }
}
