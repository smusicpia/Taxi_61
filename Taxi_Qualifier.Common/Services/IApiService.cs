using System.Threading.Tasks;
using Taxi_Qualifier.Common.Models;

namespace Taxi_Qualifier.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetTaxiAsync(string plaque, string urlBase, string servicePrefix, string controller);

        Task<bool> CheckConnectionAsync(string url);
    }

}
