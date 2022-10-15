using HR.Entities.DTOModels.VacancyAppliers;
using HR.Entities.GenericModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.ApiModels.VacancyAppliersModels.Response
{
    public class VacancyAppliersResponse : GenericResponse
    {
        public VacancyAppliersResponse()
        {
            VacancyAppliers = new List<GetAllVacancyAppliersDto>();
        }
        public List<GetAllVacancyAppliersDto> VacancyAppliers { get; set; }
    }
}
