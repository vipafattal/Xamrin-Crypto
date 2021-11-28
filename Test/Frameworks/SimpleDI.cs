using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Frameworks.Services;

namespace Test.Frameworks
{
    class SimpleDI
    {
        static readonly ICoinMarketServices marketServices = RestService.For<ICoinMarketServices>(Const.API_URL);
        public static readonly CurrencyProvider currencyProvider = new CurrencyProvider(marketServices);

    }
}