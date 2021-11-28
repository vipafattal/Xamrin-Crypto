using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bumptech.Glide;
using Bumptech.Glide.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Utils
{
    public static class ImageLoader
    {
        public static void loadRounded(this ImageView imageView, string url)
        {
            Glide.With(imageView.Context)
               .Load(url)
               .Apply(RequestOptions.CircleCropTransform())
               .Into(imageView);
        }
    }
}