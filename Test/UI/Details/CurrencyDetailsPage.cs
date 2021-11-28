using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.TextField;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Models;
using Test.Utils;
using Test.ViewModels;

namespace Test.UI
{
    [Activity(Label = "CurrencyDetailsPage", Theme = "@style/AppTheme")]
    class CurrencyDetailsPage : AppCompatActivity
    {

        static string CURRENCY_ARGS = "_CURRENCY";


        public CurrencyDetailsPage() { }

        readonly CurrencyDetailsViewModel viewModel = new CurrencyDetailsViewModel();

        public static void StartAcitivity(Context context, CryptoCurrnecy currnecy)
        {
            string serializedCurrency = JsonConvert.SerializeObject(currnecy);
            Intent intent = new Intent(context, typeof(CurrencyDetailsPage));
            intent.PutExtra(CURRENCY_ARGS, serializedCurrency);
            context.StartActivity(intent);
        }


        CryptoCurrnecy currency;
        CryptoCurrencyInfo currencyInfo;
        Conveter conveter;

        //Toolbar
        AndroidX.AppCompat.Widget.Toolbar detailsToolbar;
        TextView titleText;
        ImageView logoImage;

        //Tags
        TextView rankText;
        TextView lastupdatedText;
        TextView categoryText;

        //Converter
        ImageView logoConverterImage;
        TextView converterTitleText;
        TextView converterCurrencyName;
        TextView converterCurrencySymbol;
        TextInputLayout moneyInputText;
        TextInputLayout cryptoInputText;

        //Root
        View detailsRootUI;
        ProgressBar progressBar;

        TextView descriptionText;
        TextView priceText;
        TextView priceTitle;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.acitivty_currency_details_page);
            currency = JsonConvert.DeserializeObject<CryptoCurrnecy>(Intent.GetStringExtra(CURRENCY_ARGS));
            conveter = new Conveter(currency.usdQuote.price);
            loadUI();
        }

        void initViewes()
        {
            //Toolbar views
            detailsToolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.details_toolbar);
            logoImage = FindViewById<ImageView>(Resource.Id.details_logo_image);
            titleText = FindViewById<TextView>(Resource.Id.details_name_text);

            //Tag views
            rankText = FindViewById<TextView>(Resource.Id.details_rank_text);
            lastupdatedText = FindViewById<TextView>(Resource.Id.details_last_updated_text);
            categoryText = FindViewById<TextView>(Resource.Id.details_category_currency_text);

            //Converter views
            converterTitleText = FindViewById<TextView>(Resource.Id.converter_title_text);
            logoConverterImage = FindViewById<ImageView>(Resource.Id.converter_logo);
            converterCurrencyName = FindViewById<TextView>(Resource.Id.converter_crypto_name);
            converterCurrencySymbol = FindViewById<TextView>(Resource.Id.converter_crypto_symbole_name);
            moneyInputText = FindViewById<TextInputLayout>(Resource.Id.converter_money_input_text);
            cryptoInputText = FindViewById<TextInputLayout>(Resource.Id.converter_crypto_input_text);

            //Root
            progressBar = FindViewById<ProgressBar>(Resource.Id.details_loading_progress);
            detailsRootUI= FindViewById<View>(Resource.Id.details_root);
            descriptionText = FindViewById<TextView>(Resource.Id.details_description_text);
            priceTitle = FindViewById<TextView>(Resource.Id.details_currency_name_text);
            priceText = FindViewById<TextView>(Resource.Id.details_currency_price_text);

            initToolbar();
        }
        void initToolbar()
        {
            SetSupportActionBar(detailsToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            logoImage.loadRounded(currency.largeImageUrl);
            titleText.Text = currency.name;
        }


        async void loadUI()
        {
            initViewes();
            currencyInfo = await viewModel.GetCryptoCurrnecyInfo(currency.id);
            detailsRootUI.Visibility = ViewStates.Visible;
            progressBar.Visibility = ViewStates.Gone;
            initTags();
            initRoot();
            initConverter();
        }



        void initRoot()
        {
            rankText.Text = "Rank " + currency.rank;
            descriptionText.Text = currencyInfo.description;
            priceTitle.Text = currency.name + $" Price ({currency.symbol})";
            priceText.Text = currency.usdQuote.getFormattedPrice();
        }

        void initTags()
        {
            DateTime currentDate = DateTime.Now;
            DateTime lastUpdatedDate = currency.lastUpdateDate;
            TimeSpan lastTimeUpdatedMin = currentDate.Subtract(lastUpdatedDate);

            rankText.Text = "Rank " + currency.rank;
            categoryText.Text = currencyInfo.category;

            lastupdatedText.Append(
                lastTimeUpdatedMin.TotalMinutes < 1 ? "Now" : ((int)lastTimeUpdatedMin.TotalMinutes).ToString()
                );
        }

        void initConverter()
        {
            converterTitleText.Text = currency.symbol + " to USD Converter";

            logoConverterImage.loadRounded(currency.largeImageUrl);
            converterCurrencyName.Text = currency.name;
            converterCurrencySymbol.Text = currency.symbol;

            moneyInputText.EditText.TextChanged += (_, e) =>
            {
                double money = double.TryParse(e.Text.ToString(),out money) ? money:0;

                if (money.ToString() != conveter.currentMoney.ToString()) {
                    conveter.setMoneyAmount(money);
                    cryptoInputText.EditText.Text = conveter.currentCrypto.ToString();
                }

            }; 

            cryptoInputText.EditText.TextChanged += (_, e) =>
            {
                double cryptos = double.TryParse(e.Text.ToString(), out cryptos) ? cryptos : 1;

                if (cryptos.ToString() != conveter.currentCrypto.ToString())
                {
                    conveter.setCryptoAmount(cryptos);
                    moneyInputText.EditText.Text = conveter.currentMoney.ToString();
                }
            };

            cryptoInputText.EditText.Text = "1";

        }



        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId != Android.Resource.Id.Home)
                return base.OnOptionsItemSelected(item);
            Finish();
            return true;
        }
    }
}