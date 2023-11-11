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
            CreateMap<Activity, ActivityDTO>().ReverseMap();

            CreateMap<CreacionActivityDTO, Activity>()
                .ForMember(activity => activity.CountryActivities, opciones => opciones.MapFrom(MapCountryActivities));
        }
        private List<CountryActivity> MapCountryActivities(CreacionActivityDTO creacionActivityDTO,Activity activity)
        {
            var result = new List<CountryActivity>();

            if(creacionActivityDTO.CountryIds == null) { return result; }

            foreach (var countryId in creacionActivityDTO.CountryIds)
            {
                result.Add(new CountryActivity() { CountryId = countryId });
            }
            
            return result;
        }
    }
}
