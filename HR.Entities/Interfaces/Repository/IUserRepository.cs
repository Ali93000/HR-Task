using HR.Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Interfaces.Repository
{
    public interface IUserRepository : IGenericRepositoryAsync<DB_User>
    {
    }
}
