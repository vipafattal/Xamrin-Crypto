using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Frameworks.Services;
using Test.Models;

namespace Test.Frameworks
{
    interface ICoinMarketServices
    {
        private const string AUTHORIZATION_HEADER = "X-CMC_PRO_API_KEY";
        private const string API_TOKEN = "953f490c-3a57-42c4-8bad-e25c10e378be";

        [Get("/cryptocurrency/listings/latest")]
        [Headers(AUTHORIZATION_HEADER+":"+API_TOKEN)]
        Task<ApiResponse<CryptoCurrnecyData>> GetCryptoCurrnecy();


        [Get("/cryptocurrency/info?id={id}")]
        [Headers(AUTHORIZATION_HEADER+":"+API_TOKEN)]
        Task<ApiResponse<CryptoCurrnecyInfoData>> GetCryptoCurrnecyInfo(int id);
    }
}