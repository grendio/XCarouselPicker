using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using XCarousel.Droid.Adapters;
using XCarousel.Droid.Interfaces;
using XCarousel.Droid.Models;
using XCarousel.Droid.Views;

namespace XCarousel.Droid
{
    [Activity(Label = "XCarousel.Droid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        XCarouselView picker;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            picker = FindViewById<XCarouselView>(Resource.Id.picker);


            var products = new List<PickerItem>();

            products.Add(new DrawableItem(Resource.Drawable.CoffeeAsset));
            products.Add(new DrawableItem(Resource.Drawable.CoffeeAsset));
            products.Add(new DrawableItem(Resource.Drawable.CoffeeAsset));
            products.Add(new DrawableItem(Resource.Drawable.CoffeeAsset));
            products.Add(new DrawableItem(Resource.Drawable.CoffeeAsset));

            var adapter = new XCarouselViewAdapter(this, products, 0);
            picker.Adapter = adapter;
        }
    }
}

