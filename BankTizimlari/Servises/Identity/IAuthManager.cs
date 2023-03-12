using BankTizimlari.Domain.DTOs.AuthDTOs;

namespace BankTizimlari.Servises.Identity
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LodinDto dto);
        Task<string> CreateToken();
    }
}
