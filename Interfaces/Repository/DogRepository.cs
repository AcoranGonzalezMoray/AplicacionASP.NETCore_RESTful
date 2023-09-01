using BC_Veterinaria.Model;
using BC_Veterinaria.Model.SqlServer;
using Firebase.Auth;
using Firebase.Storage;
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
            await DeleteImage(dog.ImageUrl);
            _context.DOGS.Remove(dog);
            await _context.SaveChangesAsync();
            return;
        }
        public async Task DeleteImage(string name)
        {
            //INGRESA AQUÍ TUS PROPIAS CREDENCIALES
            string email = "prueba@gmail.com";
            string clave = "prueba";
            string ruta = "veterinarioasp-net.appspot.com";
            string api_key = "AIzaSyAqRXWkh_riIRnOQ1gefoLTLscUg5RAEtU";


            var auth = new FirebaseAuthProvider(new FirebaseConfig(api_key));
            var a = await auth.SignInWithEmailAndPasswordAsync(email, clave);

            var cancellation = new CancellationTokenSource();

            // Parsear la URL
            Uri uri = new Uri(name);

            // Obtener el nombre del archivo
            string fileName = System.IO.Path.GetFileName(uri.LocalPath);


            await new FirebaseStorage(
                ruta,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child("Fotos_Perfil")
                .Child(fileName)
                .DeleteAsync();      
        }


        public async Task<dog> GetDog(int id)
        {
            return await _context.DOGS.Where(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<dog>> GetListDogs()
        {
            return await _context.DOGS.ToListAsync();   
        }

        public async Task postDog(dog Dog, IFormFile Imagen)
        {
            //RECIBIR LOS DATOS DEL FORMULARIO
            Stream image = Imagen.OpenReadStream();
            string urlimagen = await UploadImage(image, Imagen.FileName);

            Dog.ImageUrl = urlimagen;

            _context.DOGS.Add(Dog);
            await _context.SaveChangesAsync();
          
        }

        public async Task putDog(dog DogBD, dog Dog, IFormFile image)
        {

            await DeleteImage(DogBD.ImageUrl);

            Stream imagen = image.OpenReadStream();
            string urlImagen = await UploadImage(imagen,image.FileName);
            
            DogBD.Vaccinations = Dog.Vaccinations;
            DogBD.Pathologies = Dog.Pathologies;
            DogBD.Birth = Dog.Birth;
            DogBD.Race = Dog.Race;
            DogBD.Age = Dog.Age;
            DogBD.Name = Dog.Name;
            DogBD.ImageUrl =urlImagen;
            await _context.SaveChangesAsync();
        }

        public async Task<string> UploadImage(Stream archivo, string name)
        {
            //INGRESA AQUÍ TUS PROPIAS CREDENCIALES
            string email = "prueba@gmail.com";
            string clave = "prueba";
            string ruta = "veterinarioasp-net.appspot.com";
            string api_key = "AIzaSyAqRXWkh_riIRnOQ1gefoLTLscUg5RAEtU";


            var auth = new FirebaseAuthProvider(new FirebaseConfig(api_key));
            var a = await auth.SignInWithEmailAndPasswordAsync(email, clave);

            var cancellation = new CancellationTokenSource();
            string nameNew = name+DateTime.Now.ToString().Replace("/","_").Replace(" ","_");
            var task = new FirebaseStorage(
                ruta,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child("Fotos_Perfil")
                .Child(nameNew)
                .PutAsync(archivo, cancellation.Token);


            var downloadURL = await task;


            return downloadURL;
        }
    }
}
