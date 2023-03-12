using BankTizimlari.Domain.Entities.Products;
using BankTizimlari.Servise.DTOs.ApiUsersDTOs;

namespace BankTizimlari.Servise.IServices
{
    public interface IApiUserService
    {
        Task<IList<ApiUserPrintDto>> GetAll();
        Task<ApiUserPrintDto> GetById(Guid id);
        Task Add(ApiUserAddDto dto);
        Task UpdateApiUser(Guid Id , ApiUserAddDto dto);
        Task Delete(Guid Id);
    }
}
