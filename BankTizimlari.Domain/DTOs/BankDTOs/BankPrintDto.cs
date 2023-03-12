using BankTizimlari.Domain.Entities.Products;

namespace BankTizimlari.Servise.DTOs.BankDTOs
{
    public class BankPrintDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string? PhoneNumber { get; set; }
        public long Capital { get; set; }
        public List<ApiUser> users { get; set; }

        public BankPrintDto()
        {
            users= new List<ApiUser>();
        }
    }
}
