using AutoMapper;
using Gareon.WebService.AutoMapper.Converters;
using Gareon.WebService.Cqrs.Abstractions.Commands;
using Gareon.WebService.Domain;
using Gareon.WebService.Domain.Account;
using Gareon.WebService.Presentation;

namespace Gareon.WebService.AutoMapper.Profiles
{
    public class TbUserProfile : Profile
    {
        public TbUserProfile()
        {
            this.CreateMap<TbUserRegisterDto, TbUserRegisterCommand>()
                .ConvertUsing<TbUserRegisterCommandConverter>();

            this.CreateMap<TbUser, TbUserDto>()
                .ForMember(dest => dest.Id, 
                    options => options.MapFrom(src => src.Jid))
                .ForMember(dest => dest.IsGameMaster,
                    options => options.MapFrom(src => src.Gmrank.GetValueOrDefault() == 1))
                .ForMember(dest => dest.IsGameDeveloper,
                    options => options.MapFrom(src => src.SecPrimary == 1 && src.SecContent == 1))
                .ForMember(dest => dest.UserName, options => options.MapFrom(src => src.StrUserId));
        }
    }
}