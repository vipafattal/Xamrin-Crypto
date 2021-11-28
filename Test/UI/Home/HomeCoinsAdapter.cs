using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Models;

namespace Test.UI
{
    class HomeCoinsAdapter : RecyclerView.Adapter
    {
        CryptoCurrnecy[] currnecies;
        CryptoCurrnecy[] filteredCurrnecies;

        string searchQuery = "";

        CryptoCurrnecy[] getDataList() => searchQuery.Length > 0 ? filteredCurrnecies : currnecies;


        public HomeCoinsAdapter(CryptoCurrnecy[] currnecies)
        {
            this.currnecies = currnecies;
        }



        public void searchCurrencices(string newSearchQuery)
        {

            searchQuery = newSearchQuery;
            filteredCurrnecies = currnecies.Where((e) => e.name.ToLower().Contains(searchQuery.ToLower()) ||
            e.symbol.Contains(searchQuery.ToUpper())).ToArray();
            NotifyDataSetChanged();
        }

        
        public override int ItemCount => getDataList().Length;


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_home_coin, parent, false);
            return new CoinsHomeViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {

            CryptoCurrnecy currnecy = getDataList()[position];
            (holder as CoinsHomeViewHolder).bindViewData(currnecy);

        }


    }
}