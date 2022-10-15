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
    public class UserRepository : GenericRepositoryAsync<DB_User>, IUserRepository
    {
        private readonly DbContext _context;
        public UserRepository(HRDBContext context) : base(context)
        {
            this._context = context;
        }
    
}
}
