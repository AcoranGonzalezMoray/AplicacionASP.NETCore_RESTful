using Firebase.Auth;
using Firebase.Storage;

namespace BC_Veterinaria.Interfaces.Repository
{
    public class StorageRepository:IStorageRepository
    {

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
            string nameNew = name + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_");
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
