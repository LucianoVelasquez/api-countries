using AutoMapper;
using Countries.DTOS;
using Countries.Entidades;

namespace Countries.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
        }
    }
}
