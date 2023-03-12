using BankTizimlari.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTizimlari.Servise.DTOs.BankDTOs
{
    public class BankAddDto
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string? PhoneNumber { get; set; }
        public long Capital { get; set; }
    }
}
