using BankTizimlari.Servise.DTOs.ApiUsersDTOs;
using BankTizimlari.Servise.DTOs.BankDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTizimlari.Servise.IServices
{
    public interface IBankService
    {
        Task<IList<BankPrintDto>> GetAll();
        Task<BankPrintDto> GetById(Guid id);
        Task Add(BankAddDto dto);
        Task UpdateBank(Guid Id, BankAddDto dto);
        Task Delete(Guid Id);
        Task AddUserBank(Guid UserId, Guid BankId);
    }
}
