using HR.DAL.Domain;
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
    public class VacancyAppliersRepository : GenericRepositoryAsync<DB_VacancyApplier>, IVacancyAppliersRepository
    {
        private readonly DbContext _context;
        public VacancyAppliersRepository(HRDBContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<DB_VacancyApplier>> LoadAllVacancies()
        {
            return await _context.Set<DB_VacancyApplier>()
                .Include(c=>c.Vacancy)
                .ToListAsync();
        }
    }
}
