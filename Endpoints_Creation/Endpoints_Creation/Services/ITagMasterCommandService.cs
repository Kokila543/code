using Endpoints_Creation.Models;

namespace Endpoints_Creation.Services
{
    public interface ITagMasterCommandService
    {
        Task<ResponseModel> CreateTagMasterCommand(TagMasterDto dto);
        Task<ResponseModel> DeleteTagMasterCommand(TagMasterDto dto);
    }
}
