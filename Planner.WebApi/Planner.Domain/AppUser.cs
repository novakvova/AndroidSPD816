using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Domain
{
    public class AppUser : IdentityUser<long>
    {
        public string DisplayName { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
