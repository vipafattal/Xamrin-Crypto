using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Frameworks.Services;

namespace Test.Models
{
    class CryptoCurrnecy
    {
        public int id { get; set; }

     
        public int cmc_rank { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }

        public string last_updated { get; set; }

        public Dictionary<string, Quote> quote { get; set; }

        public Quote usdQuote => quote["USD"];


        public string rank => $"#{cmc_rank}";
        public string minImageUrl => Const.IMAGE_URL + $"16x16/{id}.png";

        public string largeImageUrl => Const.IMAGE_URL + $"32x32/{id}.png";

        public string xLargeImageUrl => Const.IMAGE_URL + $"64x64/{id}.png";


        public DateTime lastUpdateDate => Convert.ToDateTime(last_updated);
    }


    class Quotes
    {
        public Dictionary<string, Quote> USD { get; set; }
    }

    class Quote
    {
        public double price { get; set; }

        public String getFormattedPrice() => String.Format("{0:C}", price);
    }
}