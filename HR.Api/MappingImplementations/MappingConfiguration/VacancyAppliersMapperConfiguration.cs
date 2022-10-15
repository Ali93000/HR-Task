using AutoMapper;
using HR.Entities.ApiModels.UserModels.Response;
using HR.Entities.ApiModels.VacancyAppliersModels.Request;
using HR.Entities.ApiModels.VacancyAppliersModels.Response;
using HR.Entities.DBModels;
using HR.Entities.DTOModels.UserDto;
using HR.Entities.DTOModels.VacancyAppliers;
using HR.Entities.Mapping.MappingConfiguration;

namespace HR.Api.MappingImplementations.MappingConfiguration
{
    public class VacancyAppliersMapperConfiguration : IVacancyAppliersMapperConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // get all appliers
                cfg.CreateMap<DB_VacancyApplier, GetAllVacancyAppliersDto>()
                .ForMember(des=>des.VacancyName, map=>map.MapFrom(src=>src.Vacancy.NameEn));

                cfg.CreateMap<List<DB_VacancyApplier>, VacancyAppliersResponse>()
                    .ForMember(des => des.VacancyAppliers, map => map.MapFrom(src => src));

                // create applier
                cfg.CreateMap<CreateVacancyApplierRequest, DB_VacancyApplier>();
            });
            return config.CreateMapper();
        }
    }
}
