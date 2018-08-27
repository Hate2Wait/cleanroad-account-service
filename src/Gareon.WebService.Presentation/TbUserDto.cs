using System;

namespace Gareon.WebService.Presentation
{
    public class TbUserDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsGameMaster { get; set; }

        public bool IsGameDeveloper { get; set; }

        public bool IsBlocked { get; set; }

        public DateTime? BlockedUntil { get; set; }
    }
}