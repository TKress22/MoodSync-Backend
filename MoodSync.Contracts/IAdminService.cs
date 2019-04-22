using MoodSync.Data;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MoodSync.Contracts
{
    public interface IAdminService
    {
        bool IsAdminUser();
        IEnumerable<ApplicationUser> GetUserList();
        IEnumerable<IdentityRole> GetRolesList();
    }
}
