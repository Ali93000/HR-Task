using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.DBModels
{
    public class DB_Role
    {
        public DB_Role()
        {
            UserRoles = new HashSet<DB_UserRole>();
        }

        public int Id { get; set; }
        public string? RoleName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public virtual ICollection<DB_UserRole> UserRoles { get; set; }
    }
}
