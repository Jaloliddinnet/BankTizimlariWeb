using Microsoft.AspNetCore.Identity;

namespace BankTizimlari.Domain.Entities.Products
{
    public class ApiUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportSery { get; set; }
        public string? Region { get; set; }
        public int? Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public List<Bank> bankName { get; set; }

        public ApiUser()
        {
            bankName= new List<Bank>();
        }

    }
}
