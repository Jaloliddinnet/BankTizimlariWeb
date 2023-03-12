using BankTizimlari.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTizimlari.Servise.DTOs.ApiUsersDTOs
{
    public class ApiUserAddDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportSery { get; set; }
        public string? Region { get; set; }
        public int? Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
