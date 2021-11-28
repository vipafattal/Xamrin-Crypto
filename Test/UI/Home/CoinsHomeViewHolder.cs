using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Bumptech.Glide;
using Bumptech.Glide.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Models;
using Test.Utils;

namespace Test.UI
{
    class CoinsHomeViewHolder : RecyclerView.ViewHolder
    {

        Context context;

        public ImageView image { get; private set; }
        public TextView rank { get; private set; }
        public TextView name { get; private set; }
        public TextView symbol { get; private set; }
        public TextView price { get; private set; }

        public CoinsHomeViewHolder(View itemView) : base(itemView)
        {
            image = itemView.FindViewById<ImageView>(Resource.Id.item_coin_image);

            rank = itemView.FindViewById<TextView>(Resource.Id.item_rank_text);
            name = itemView.FindViewById<TextView>(Resource.Id.item_coin_name_text);
            symbol = itemView.FindViewById<TextView>(Resource.Id.item_coin_symbol_text);
            price = itemView.FindViewById<TextView>(Resource.Id.item_coin_price_text);

            context = ItemView.Context;
        }

        public void bindViewData(CryptoCurrnecy currnecy)
        {
            rank.Text = currnecy.rank;
            name.Text = currnecy.name;
            symbol.Text = currnecy.symbol;
            price.Text = currnecy.usdQuote.getFormattedPrice();

            image.loadRounded(currnecy.largeImageUrl);

            ItemView.Click += (_, __) =>
            {
                CurrencyDetailsPage.StartAcitivity(context, currnecy);
            };
        }



    }
}