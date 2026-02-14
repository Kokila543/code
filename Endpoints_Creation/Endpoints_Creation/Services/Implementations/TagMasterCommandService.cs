using Endpoints_Creation.Models;

namespace Endpoints_Creation.Services.Implementations
{
    public class TagMasterCommandService : ITagMasterCommandService

    {
        public Task<ResponseModel> CreateTagMasterCommand(TagMasterDto dto)
        {
            return Task.FromResult(new ResponseModel
            {
                Message = ""
            });
        }

        public Task<ResponseModel> DeleteTagMasterCommand(TagMasterDto dto)
        {
            return Task.FromResult(new ResponseModel
            {
                Message = ""
            });
        }
    }
}
