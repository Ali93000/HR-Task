using AutoMapper;
using HR.Entities.ApiModels.UserModels.Response;
using HR.Entities.ApiModels.VacancyModels.Request;
using HR.Entities.ApiModels.VacancyModels.Response;
using HR.Entities.DBModels;
using HR.Entities.DTOModels.UserDto;
using HR.Entities.DTOModels.VacancyDto;
using HR.Entities.Mapping.MappingConfiguration;

namespace HR.Api.MappingImplementations.MappingConfiguration
{
    public class VacancyMapperConfiguration : IVacancyMapperConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Get All Vacancies
                cfg.CreateMap<DB_Vacancy, GetAllVacanciesDto>();
                cfg.CreateMap<List<DB_Vacancy>, VacanciesResponse>()
                    .ForMember(des => des.Vacancies, map => map.MapFrom(src => src));

                // Create Vacancy
                cfg.CreateMap<CreateVacancyRequest, DB_Vacancy>();
            });
            return config.CreateMapper();
        }
    }
}
