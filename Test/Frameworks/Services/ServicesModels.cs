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
using Test.Models;

namespace Test.Frameworks.Services
{
    class CryptoCurrnecyData
    {
        public CryptoCurrnecy[] data { get; set; }

        public static implicit operator CryptoCurrnecyData(ApiResponse<CryptoCurrnecyData> v)
        {
            throw new NotImplementedException();
        }
    }

    class CryptoCurrnecyInfoData
    {
        public Dictionary<string, CryptoCurrencyInfo> data { get; set; }
    }
}