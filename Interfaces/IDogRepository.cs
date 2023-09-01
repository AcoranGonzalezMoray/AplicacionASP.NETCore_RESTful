using BC_Veterinaria.Model;

namespace BC_Veterinaria.Interfaces
{
    public interface IDogRepository
    {
        Task<List<dog>> GetListDogs();
        Task DeleteDog(dog dog);
        Task<dog> GetDog(int id);
        Task putDog(dog dogBD, dog Dog);
        Task postDog(dog Dog);
    }
}
