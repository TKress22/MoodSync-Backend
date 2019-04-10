using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MoodSync.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodsync.Services
{
    public class UserService
    {
        private readonly Guid _creatorId;

        public UserService(Guid creatorId)
        {
            _creatorId = creatorId;
        }

        public bool SetRole(string newRole)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.AddToRole(_creatorId.ToString(), newRole);
            return true;
        }
    }
}
