using CleanArquitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Core.Interfaces.Repositories
{
    public interface IUserRepository:IBaseRepository<User>
    {
        Task LoginJWT(string username, string password);
    }
}
