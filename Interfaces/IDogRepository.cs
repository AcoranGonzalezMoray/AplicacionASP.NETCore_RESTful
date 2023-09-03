using BC_Veterinaria.Model;

namespace BC_Veterinaria.Interfaces
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetListDogs();
        Task DeleteDog(Dog dog);
        Task<Dog> GetDog(int id);
        Task putDog(Dog dogBD, Dog Dog);
        Task postDog(Dog Dog);
    }
}
