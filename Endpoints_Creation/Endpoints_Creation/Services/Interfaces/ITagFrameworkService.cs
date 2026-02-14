using Endpoints_Creation.Services.Interfaces;

namespace Endpoints_Creation.Services.Interfaces
{
    public interface ITagFrameworkService
    {
        ITagMasterQueryService TagMasterQueryService { get; }
        ITagAssociationsValidationService TagAssociationsValidationService { get; }
        ITagAssociationCommandService TagAssociationCommandService { get; }
        ITagMasterValidationService TagMasterValidationService { get; }
        ITagMasterCommandService TagMasterCommand { get; }
    }
}
