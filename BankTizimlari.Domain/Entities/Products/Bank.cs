using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTizimlari.Domain.Entities.Products
{
    public class Bank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string? PhoneNumber { get; set; }
        public long Capital { get; set; }
        public List<ApiUser> userName { get; set; }

        public Bank()
        {
            userName= new List<ApiUser>();
        }

    }
}
