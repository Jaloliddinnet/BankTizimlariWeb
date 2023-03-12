using AutoMapper;
using BankTizimlari.Domain.Entities.Products;
using BankTizimlari.Servise.DTOs.ApiUsersDTOs;
using BankTizimlari.Servise.DTOs.BankDTOs;
using BankTizimlari.Servise.IServices;
using BankTIzimlati.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTizimlari.Servise.Services
{
    public class BankService : IBankService
    {
        IBankRepositories repositori;
        IMapper mapper;
        public BankService(IBankRepositories repositorie, IMapper mapper)
        {
            this.repositori = repositorie;
            this.mapper = mapper;
        }

        public async Task Add(BankAddDto dto)
        {
            var Bank = mapper.Map<Bank>(dto);
            await repositori.Add(Bank);
        }

        public  async Task AddUserBank(Guid UserId, Guid BankId)
        {
           await  repositori.AddUseerBank(UserId, BankId); 
        }

        public Task Delete(Guid Id)
        {
            return repositori.DeleteById(Id);
        }

        public async Task<IList<BankPrintDto>> GetAll()
        {
            return mapper.Map<IList<BankPrintDto>>(await repositori.GetAll());
        }

        public async Task<BankPrintDto> GetById(Guid id)
        {
            return mapper.Map<BankPrintDto>(await repositori.GetById(id));
        }

        public async Task UpdateBank(Guid Id, BankAddDto dto)
        {
            var bank = mapper.Map<Bank>(dto);
            await repositori.Update(Id, bank);
        }
    }
}
