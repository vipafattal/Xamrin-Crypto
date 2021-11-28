
using System.Threading.Tasks;
using Test.Frameworks;
using Test.Models;

namespace Test.ViewModels
{
    class CurrencyDetailsViewModel
    {
        public CurrencyDetailsViewModel() { }

        private CurrencyProvider currencyProvider = SimpleDI.currencyProvider;

        public async Task<CryptoCurrencyInfo> GetCryptoCurrnecyInfo(int id) => await currencyProvider.GetCryptoCurrnecyInfo(id);
    }
}