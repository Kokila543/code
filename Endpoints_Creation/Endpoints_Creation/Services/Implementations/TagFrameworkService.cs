using Endpoints_Creation.Services.Interfaces;

namespace Endpoints_Creation.Services.Implementations
{
    public class TagFrameworkService:ITagFrameworkService
    {
        public ITagMasterQueryService TagMasterQueryService { get; }
        public ITagAssociationsValidationService TagAssociationsValidationService { get; }
        public ITagAssociationCommandService TagAssociationCommandService { get; }
        public ITagMasterValidationService TagMasterValidationService { get; }
        public ITagMasterCommandService TagMasterCommand { get; }

        public TagFrameworkService(
            ITagMasterQueryService tagMasterQueryService,
            ITagAssociationsValidationService tagAssociationsValidationService,
            ITagAssociationCommandService tagAssociationCommandService,
             ITagMasterValidationService tagMasterValidationService,
        ITagMasterCommandService tagMasterCommand)
        {
            TagMasterQueryService = tagMasterQueryService;
            TagAssociationsValidationService = tagAssociationsValidationService;
            TagAssociationCommandService = tagAssociationCommandService;
            TagMasterValidationService = tagMasterValidationService;
            TagMasterCommand = tagMasterCommand;
        }
    }
}
