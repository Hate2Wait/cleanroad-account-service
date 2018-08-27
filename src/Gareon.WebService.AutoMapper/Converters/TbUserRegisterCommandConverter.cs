using AutoMapper;
using Gareon.WebService.Cqrs.Abstractions.Commands;
using Gareon.WebService.Presentation;
using Microsoft.AspNetCore.Http;

namespace Gareon.WebService.AutoMapper.Converters
{
    public class TbUserRegisterCommandConverter : ITypeConverter<TbUserRegisterDto, TbUserRegisterCommand>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public TbUserRegisterCommandConverter(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public TbUserRegisterCommand Convert(TbUserRegisterDto source, TbUserRegisterCommand destination, ResolutionContext context)
        {
            return new TbUserRegisterCommand(source.UserName, source.Password, source.Email, source.Name,
                source.SecretCode, this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress);
        }
    }
}