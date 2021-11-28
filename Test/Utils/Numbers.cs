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

namespace Test.Utils
{
    public static class Numbers
    {
        public static double truncate(this double value, int precision)
        {
            decimal power = (decimal)Math.Pow(10, precision);
            return (double)(Math.Truncate((decimal)value * power) / power);
        }
    }
}