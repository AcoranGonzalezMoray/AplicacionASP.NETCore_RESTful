using BC_Veterinaria.Model;
using BC_Veterinaria.Model.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace BC_Veterinaria.Interfaces.Repository
{
    public class UserRepository : IUserRepository
    {
        private sqlServerContext _context;
        public UserRepository(sqlServerContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(string email, string password)
        {
            User user = await _context.USERS.Where(d=> d.Email==email && d.Password==password).FirstOrDefaultAsync();
            return user;
        }

        public Task<User[]> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task PostUser(User user)
        {
            _context.USERS.Add(user);
            await _context.SaveChangesAsync();
            return;
        }
    }
}
