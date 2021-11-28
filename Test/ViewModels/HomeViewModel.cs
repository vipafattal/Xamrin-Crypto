using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Frameworks;
using Test.Models;

namespace Test.ViewModel
{
    class HomeViewModel
    {

        public HomeViewModel() { }

        private CurrencyProvider currencyProvider = SimpleDI.currencyProvider;

        public async Task<CryptoCurrnecy[]> GetCryptoCurrnecies() => await currencyProvider.GetCryptoCurrnecies();


    }
}