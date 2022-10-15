using HR.Entities.DTOModels.VacancyDto;
using HR.Entities.GenericModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.ApiModels.VacancyModels.Response
{
    public class VacanciesResponse : GenericResponse
    {
        public VacanciesResponse()
        {
            Vacancies = new List<GetAllVacanciesDto>();
        }
        public List<GetAllVacanciesDto> Vacancies { get; set; }
    }
}
