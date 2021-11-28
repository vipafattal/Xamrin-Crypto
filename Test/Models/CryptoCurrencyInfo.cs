using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Models
{
    class CryptoCurrencyInfo
    {
        public int id { get; set; }
        public string category { get; set; }
        public string description { get; set; }

        [JsonProperty(PropertyName = "tag-names")]
        public string[] tags { get; set; }
    }
}