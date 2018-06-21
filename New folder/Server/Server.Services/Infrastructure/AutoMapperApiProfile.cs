using AutoMapper;
using Vino.Server.Data.Common;
using Vino.Shared.Constants;
using Vino.Shared.Dto;
using Vino.Shared.Entities;

namespace Vino.Server.Services.Infrastructure
{
    public class AutoMapperApiProfile : Profile
    {
        public AutoMapperApiProfile()
        {
            CreateMap<Lookup, LookupDto>().ReverseMap();
		}
    }
}

