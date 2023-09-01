namespace BC_Veterinaria.Interfaces
{
    public interface IStorageRepository
    {

        Task<string> UploadImage(Stream archivo, string name);
        Task DeleteImage(string url);
    }
}
