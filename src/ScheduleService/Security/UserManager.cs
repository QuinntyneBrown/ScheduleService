using ScheduleService.Data.Model;
using System.Threading.Tasks;
using System.Security.Principal;
using ScheduleService.Data;
using System.Data.Entity;

namespace ScheduleService.Security
{
    public interface IUserManager
    {
        Task<User> GetUserAsync(IPrincipal user);
    }

    public class UserManager : IUserManager
    {
        public UserManager(IScheduleServiceContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(IPrincipal user) => await _context.Users.SingleAsync(x => x.Username == user.Identity.Name);

        protected readonly IScheduleServiceContext _context;
    }
}
