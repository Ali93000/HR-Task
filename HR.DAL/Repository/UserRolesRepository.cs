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
    public class UserRolesRepository : GenericRepositoryAsync<DB_UserRole>, IUserRolesRepository
    {
        private readonly DbContext _context;
        public UserRolesRepository(HRDBContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<DB_UserRole>> GetAllUserRoles(int userId)
        {
            var roles = await _context.Set<DB_UserRole>()
                .Include(c=>c.Role)
                .Where(c=>c.UserId == userId)
                .ToListAsync();
            return roles;
        }
    }
}
