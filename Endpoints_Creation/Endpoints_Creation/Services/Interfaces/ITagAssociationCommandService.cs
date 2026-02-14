using Endpoints_Creation.Models;

namespace Endpoints_Creation.Services.Interfaces
{
    public interface ITagAssociationCommandService
    {
        Task<ResponseModel> CreateTagAssociationCommand(TagAssociationsDto dto);

        Task<ResponseModel> DeleteTagAssociationsCommand(TagAssociationsDto dto);

        Task<ResponseModel> CreateTagAssociation(TagAssociationRequestDto dto);
        Task<ResponseModel> CreateTagAssociationbuilt(TagMasterDtos dto);


    }
}
