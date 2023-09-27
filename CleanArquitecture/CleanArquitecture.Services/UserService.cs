using CleanArquitecture.Core.Entities;
using CleanArquitecture.Core.Interfaces.Repositories;
using CleanArquitecture.Core.Interfaces.Services;

namespace CleanArquitecture.Services
{
    public class UserService :BaseService<User> ,IUserService
    {
        internal readonly IUserRepository _uRepository;
        public UserService(IBaseRepository<User> tRepository_, IUserRepository uRepository_) : base(tRepository_)
        {
            _uRepository = uRepository_;
        }

        public Task LoginJWT(string username, string password)
        {
            return _uRepository.LoginJWT(username, password);
        }
    }
}
