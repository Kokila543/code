using AutoMapper;
using Endpoints_Creation.Models;
using Endpoints_Creation.Models;

namespace Hashtag.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TagAssociationsInputModel, TagAssociationsDto>();
            CreateMap<TagMasterInputModel, TagMasterDto>();

        }
    }
}
