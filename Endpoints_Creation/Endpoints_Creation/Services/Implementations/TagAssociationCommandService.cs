using Endpoints_Creation.Models;
using Endpoints_Creation.Services.Interfaces;

using System;

namespace Endpoints_Creation.Services.Implementations
{
    public class TagAssociationCommandService
        : ITagAssociationCommandService
    {
        private readonly AppContext _context;
        public TagAssociationCommandService(AppContext context)
        {
            _context = context;
        }
        public Task<ResponseModel> CreateTagAssociationCommand(
            TagAssociationsDto dto)
        {
            return Task.FromResult(new ResponseModel
            {
                Message = "Created successfully"
            });
        }

        public Task<ResponseModel> DeleteTagAssociationsCommand(
            TagAssociationsDto dto)
        {
            return Task.FromResult(new ResponseModel
            {
                Message = "Deleted successfully"
            });
        }

        public Task<ResponseModel> CreateTagAssociation(
            TagAssociationRequestDto dto)
        {
            return Task.FromResult(new ResponseModel
            {
                Message = "Created successfully"
            });
        }
        // public Task<ResponseModel> CreateTagAssociationbuilt(
        //TagMasterDtos dto)
        // {
        //     return Task.FromResult(new ResponseModel
        //     {
        //         Message = "Created successfully"
        //     });
        // }

        public async Task<ResponseModel> CreateTagAssociationbuilt(TagMasterDtos request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));



            var tagmaster = new TagMasterDtos
            {
                taSource = request.taSource,
                tagAssociationsRefEntity = request.tagAssociationsRefEntity
            };

            await _context..AddAsync(benchType);
            await _context.SaveChangesAsync();

            return benchType;

        }
    }
}
