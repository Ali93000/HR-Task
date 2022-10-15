using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.DBModels
{
    public class DB_User
    {
        public DB_User()
        {
            UserRoles = new HashSet<DB_UserRole>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public virtual ICollection<DB_UserRole> UserRoles { get; set; }
    }
}
