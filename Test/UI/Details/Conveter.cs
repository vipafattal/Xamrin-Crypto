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
using Test.Utils;

namespace Test.UI
{
    class Conveter
    {
        double singleCryptoInMoney;

        public double currentCrypto = 0;
        public double currentMoney = 0;

        public Conveter(double singleCryptoInMoney)
        {
            this.singleCryptoInMoney = singleCryptoInMoney;
        }

        public void setCryptoAmount(double cryptos)
        {
            currentCrypto = cryptos;
            currentMoney = (singleCryptoInMoney * currentCrypto).truncate(2);
        }

        public void setMoneyAmount(double money)
        {
            currentMoney = money.truncate(2);
            currentCrypto = currentMoney / singleCryptoInMoney;
        }

        public string formattedMoney => String.Format("{0:C}", currentMoney).Replace("$", "");
    }
}