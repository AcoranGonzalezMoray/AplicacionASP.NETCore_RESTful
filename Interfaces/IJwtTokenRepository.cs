namespace BC_Veterinaria.Interfaces
{
    public interface IJwtTokenRepository
    {
        string GenToken(string email, string passwd);
    }
}
