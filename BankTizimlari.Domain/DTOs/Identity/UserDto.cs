using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTizimlari.Domain.DTOs.Identity
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportSery { get; set; }
        public string? PhoneNumber { get; set; }

        public string[] Roles { get; set; }
        public string Region { get; set; }
        public string Token { get; set; }
    }
}
