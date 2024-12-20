using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Taxi_Qualifier.Web.Helpers
{
    public interface IBlobHelper
    {
        Task<string> UploadBlobAsync(IFormFile file, string containerName);

        Task<string> UploadBlobAsync(byte[] file, string containerName);

        Task<string> UploadBlobAsync(string image, string containerName);
    }
}