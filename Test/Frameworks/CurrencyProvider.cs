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
using System.Threading.Tasks;
using Test.Frameworks.Services;
using Test.Models;

namespace Test.Frameworks
{
    class CurrencyProvider
    {


        ICoinMarketServices apiServices;
        public CurrencyProvider(ICoinMarketServices services)
        {
            this.apiServices = services;
        }

        public async Task<CryptoCurrnecy[]> GetCryptoCurrnecies()
        {
            ApiResponse<CryptoCurrnecyData> apiResponse = await apiServices.GetCryptoCurrnecy();
         
            if (apiResponse.IsSuccessStatusCode)
                return apiResponse.Content.data;
            else
                return Array.Empty<CryptoCurrnecy>();

        }

        public async Task<CryptoCurrencyInfo> GetCryptoCurrnecyInfo(int id)
        {
            ApiResponse<CryptoCurrnecyInfoData> apiResponse = await apiServices.GetCryptoCurrnecyInfo(id);
          
            if (apiResponse.IsSuccessStatusCode)
            {
                Dictionary<string, CryptoCurrencyInfo> data = apiResponse.Content.data;
                return data.First().Value;
            }
            else
                return null;

        }


    }
}