using BC_Veterinaria.Model;
using BC_Veterinaria.Model.SqlServer;
using Microsoft.EntityFrameworkCore;



namespace BC_Veterinaria.Interfaces.Repository
{
    public class DogRepository:IDogRepository
    {
        private readonly sqlServerContext _context;

        public DogRepository(sqlServerContext context) {
            _context = context;
        }

        public async Task DeleteDog(dog dog)
        {
            _context.DOGS.Remove(dog);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<dog> GetDog(int id)
        {
            return await _context.DOGS.Where(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<dog>> GetListDogs()
        {
            return await _context.DOGS.ToListAsync();   
        }

        public async Task postDog(dog Dog)
        {
            _context.DOGS.Add(Dog);
            await _context.SaveChangesAsync();
          
        }

        public async Task putDog(dog DogBD, dog Dog)
        {

            
            DogBD.Vaccinations = Dog.Vaccinations;
            DogBD.Pathologies = Dog.Pathologies;
            DogBD.Birth = Dog.Birth;
            DogBD.Race = Dog.Race;
            DogBD.Age = Dog.Age;
            DogBD.Name = Dog.Name;
            DogBD.ImageUrl = Dog.ImageUrl;
            await _context.SaveChangesAsync();
        }

    }
}
