using CloudinaryDotNet.Actions;

namespace RunGroopWebAppp.Interfaces
{
    public interface IPhotoServices
    {

        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);

    }
}
