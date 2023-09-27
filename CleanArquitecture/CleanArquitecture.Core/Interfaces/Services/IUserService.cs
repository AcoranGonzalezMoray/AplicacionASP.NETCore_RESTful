using CleanArquitecture.Core.Entities;


namespace CleanArquitecture.Core.Interfaces.Services
{
    public interface IUserService:IBaseService<User>
    {
        Task LoginJWT(string username, string password);
    }
}
