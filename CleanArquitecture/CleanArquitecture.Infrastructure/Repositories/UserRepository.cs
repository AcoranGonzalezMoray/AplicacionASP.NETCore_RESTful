using CleanArquitecture.Core.Entities;
using CleanArquitecture.Core.Interfaces.Repositories;
using CleanArquitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        internal AppDbContext _context;
        internal DbSet<User> dbSet;
        public UserRepository(AppDbContext context) : base(context)
        {
            this._context = context;
            this.dbSet = context.Set<User>();
        }

        public Task LoginJWT(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
