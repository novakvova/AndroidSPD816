using Planner.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Application.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateToken(AppUser user);
    }
}
