using AutoMapper;
using BankTizimlari.Domain.Entities.Products;
using BankTizimlari.Servise.DTOs.ApiUsersDTOs;
using BankTizimlari.Servise.IServices;
using BankTIzimlati.Data.IRepositories;

namespace BankTizimlari.Servise.Services
{
    public class ApiUserService : IApiUserService
    {
        IApiUserRepositorie repositori;
        IMapper mapper;
        public ApiUserService(IApiUserRepositorie repositori, IMapper mapper)
        {
            this.repositori = repositori;
            this.mapper = mapper;
        }

        public async Task Add(ApiUserAddDto dto)
        {
            var User =  mapper.Map<ApiUser>(dto);
            await repositori.Add(User);
        }

        public  Task Delete(Guid Id)
        {
            return  repositori.Delete(Id);
        }

    public async Task<IList<ApiUserPrintDto>> GetAll()
    {
        return mapper.Map<IList<ApiUserPrintDto>>(await repositori.GetAll());
    }

    public async Task<ApiUserPrintDto> GetById(Guid id)
        {
            return mapper.Map<ApiUserPrintDto>(await repositori.GetById(id));
        }

        public async Task UpdateApiUser(Guid Id, ApiUserAddDto dto)
        {
           var user = mapper.Map<ApiUser>(dto);
            await repositori.Update(Id, user);
        }
    }
}
