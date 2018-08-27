using System;
using AutoMapper;
using Gareon.WebService.Domain;
using Gareon.WebService.Presentation;

namespace Gareon.WebService.AutoMapper.Converters
{
    public class UniqueKillDtoTimeResolver : IValueResolver<UniqueKill, UniqueKillDto, DateTime>
    {
        public DateTime Resolve(UniqueKill source, UniqueKillDto destination, DateTime destMember, ResolutionContext context)
        {
            return DateTime.Parse(source.TimeString);
        }
    }
}