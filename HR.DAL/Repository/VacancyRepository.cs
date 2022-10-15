using HR.DAL.Domain;
using HR.Entities.ApiModels.VacancyModels.Response;
using HR.Entities.DBModels;
using HR.Entities.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Repository
{
    public class VacancyRepository : GenericRepositoryAsync<DB_Vacancy>, IVacancyRepository
    {
        private readonly DbContext _context;
        public VacancyRepository(HRDBContext context) : base(context)
        {
            this._context = context;
        }
    }
}
