using AutoMapper;
using Gareon.UserService.AutoMapper.Converters;
using Gareon.UserService.Cqrs.Abstractions.Commands;
using Gareon.UserService.Domain;
using Gareon.UserService.Presentation;

namespace Gareon.UserService.AutoMapper.Profiles
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