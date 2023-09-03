using BC_Veterinaria.Model;

namespace BC_Veterinaria.Interfaces
{
    public interface IUserRepository
    {
        Task<User[]> GetUsers();
        Task<User> GetUser(string email, string password);
        Task PostUser(User user);
    }
}
