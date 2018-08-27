using AutoMapper;
using Gareon.WebService.AutoMapper.Converters;
using Gareon.WebService.Domain;
using Gareon.WebService.Presentation;

namespace Gareon.WebService.AutoMapper.Profiles
{
    public class UniqueKillProfile : Profile
    {
        public UniqueKillProfile()
        {
            this.CreateMap<UniqueKill, UniqueKillDto>()
                .ForMember(dest => dest.UniqueName, opt => opt.ResolveUsing<UniqueKillDtoUniqueNameResolver>())
                .ForMember(dest => dest.KilledAt, opt => opt.ResolveUsing<UniqueKillDtoTimeResolver>());
        }
    }
}