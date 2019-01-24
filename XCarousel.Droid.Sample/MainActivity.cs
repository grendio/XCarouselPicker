using Android.App;
using Android.OS;
using System.Collections.Generic;
using XCarousel.Droid.Interfaces;
using XCarousel.Droid.Views;
using XCarousel.Droid.Adapters;
using XCarousel.Droid.Models;
using Android.Widget;

namespace XCarousel.Droid.Sample
{
    [Activity(Label = "XCarousel.Droid.Sample", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var picker = FindViewById<XCarouselView>(Resource.Id.picker);
            var textView = FindViewById<TextView>(Resource.Id.Selected);
            var products = new List<PickerItem>();

            products.Add(new DrawableItem(Resource.Drawable.CoffeeAsset));
            products.Add(new DrawableItem(Resource.Drawable.CoffeeAsset));
            products.Add(new DrawableItem(Resource.Drawable.CoffeeAsset));
            products.Add(new DrawableItem(Resource.Drawable.CoffeeAsset));
            products.Add(new DrawableItem(Resource.Drawable.CoffeeAsset));
            products.Add(new DrawableItem(Resource.Drawable.CoffeeAsset));
            products.Add(new DrawableItem(Resource.Drawable.CoffeeAsset));

            picker.Items = products;
            picker.FadeColor = "#ecf0f1";

            textView.Text = $"Selected: {picker.Selected}";
            picker.PageSelected += (sender, e) => { textView.Text = $"Selected: {picker.Selected}"; };
        }
    }
}

