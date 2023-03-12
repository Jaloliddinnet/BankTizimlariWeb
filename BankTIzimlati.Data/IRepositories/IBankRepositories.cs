using BankTizimlari.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTIzimlati.Data.IRepositories
{
    public interface IBankRepositories
    {
        Task<IList<Bank>> GetAll();
        Task<Bank> GetById(Guid Id);
        Task Add(Bank bank);
        Task DeleteById(Guid Id);
        Task Update(Guid Id, Bank bank);
        Task AddUseerBank(Guid IdUser, Guid IdBank);
    }
}
