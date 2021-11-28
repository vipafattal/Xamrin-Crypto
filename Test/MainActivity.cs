using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using Google.Android.Material.TextField;
using Test.Models;
using Test.UI;
using Test.ViewModel;

namespace Test
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true,WindowSoftInputMode = SoftInput.AdjustPan)]
    public class MainActivity : AppCompatActivity
    {
        readonly HomeViewModel viewModel = new HomeViewModel();

        RecyclerView recyclerview;
        ProgressBar progressBar;
        TextInputLayout saerchTextInput;
        View homeUI;
        
        HomeCoinsAdapter recyclerAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            recyclerview = FindViewById<RecyclerView>(Resource.Id.coins_recycler);
            saerchTextInput = FindViewById<TextInputLayout>(Resource.Id.coins_search_input_text);
            progressBar = FindViewById<ProgressBar>(Resource.Id.coins_loading_progress);
            homeUI = FindViewById<View>(Resource.Id.home_ui);

            loadUI();
        }


        async void loadUI()
        {
            progressBar.Visibility = ViewStates.Visible;
            CryptoCurrnecy[] currnecies = await viewModel.GetCryptoCurrnecies();

            progressBar.Visibility = ViewStates.Gone;
            homeUI.Visibility = ViewStates.Visible;

            if (currnecies != null)
            {
                recyclerAdapter = new HomeCoinsAdapter(currnecies);
                recyclerview.SetAdapter(recyclerAdapter);

        
                saerchTextInput.EditText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
                {
                    recyclerAdapter.searchCurrencices(e.Text.ToString());
                };
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}