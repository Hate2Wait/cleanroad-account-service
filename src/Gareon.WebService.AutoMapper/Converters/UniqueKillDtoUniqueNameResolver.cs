using System.Linq;
using AutoMapper;
using Gareon.ServiceBase.IdentifierMappings;
using Gareon.WebService.Domain;
using Gareon.WebService.Presentation;

namespace Gareon.WebService.AutoMapper.Converters
{
    public class UniqueKillDtoUniqueNameResolver : IValueResolver<UniqueKill, UniqueKillDto, string>
    {
        public string Resolve(UniqueKill source, UniqueKillDto destination, string destMember, ResolutionContext context)
        {
            var (_, name) = UniqueNameMappings
                .Map
                .FirstOrDefault(map => map.code == source.MobName);

            return string.IsNullOrEmpty(name) ? source.MobName : name;
        }
    }
}