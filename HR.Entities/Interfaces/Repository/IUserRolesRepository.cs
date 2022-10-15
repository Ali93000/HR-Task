using HR.Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Interfaces.Repository
{
    public interface IUserRolesRepository : IGenericRepositoryAsync<DB_UserRole>
    {
        Task<List<DB_UserRole>> GetAllUserRoles(int userId);
    }
}
