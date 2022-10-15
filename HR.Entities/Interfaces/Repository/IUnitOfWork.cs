using HR.Entities.GenericModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveAsync();
        Task<GenericResponse> CheckDbConnectionStatus();
        IUserRepository UserRepository { get; set; }
        IUserRolesRepository UserRolesRepository { get; set; }
        IVacancyRepository VacancyRepository { get; set; }
        IVacancyAppliersRepository VacancyAppliersRepository { get; set; }
    }
}
