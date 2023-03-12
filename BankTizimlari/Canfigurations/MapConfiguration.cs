using AutoMapper;
using BankTizimlari.Domain.DTOs.Identity;
using BankTizimlari.Domain.Entities.Products;
using BankTizimlari.Servise.DTOs.ApiUsersDTOs;
using BankTizimlari.Servise.DTOs.BankDTOs;

namespace BankTizimlari.Canfigurations
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            CreateMap<ApiUserAddDto, ApiUser>()
                .ReverseMap();
            CreateMap<ApiUserPrintDto, ApiUser>()
                .ForMember(p => p.bankName, c => c.MapFrom(x => x.banks.Select(s => s.Name)))
                .ReverseMap();

            CreateMap<BankAddDto, Bank>()
                .ReverseMap();
            CreateMap<BankPrintDto, Bank>()
                .ForMember(p => p.userName, c => c.MapFrom(x => x
                    .users.Select(s => s.FirstName + " " + s.LastName)))
                .ReverseMap();

            CreateMap<ApiUser, UserDto>().ReverseMap();
        }
    }
}
