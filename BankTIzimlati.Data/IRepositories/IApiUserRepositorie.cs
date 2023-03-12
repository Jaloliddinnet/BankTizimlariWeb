using BankTizimlari.Domain.Entities.Products;

namespace BankTIzimlati.Data.IRepositories
{
    public interface IApiUserRepositorie
    {
        Task<IList<ApiUser>> GetAll();
        Task<ApiUser> GetById(Guid Id);
        Task Add(ApiUser user);
        Task Update(Guid Id ,ApiUser user);
        Task Delete(Guid Id);
    }
}
