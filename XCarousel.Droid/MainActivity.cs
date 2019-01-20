using System.Collections.Generic;
using Android.App;
using Android.OS;
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

            var textItems = new List<PickerItem>();
            textItems.Add(new TextItem("TEST1", 20));
            textItems.Add(new TextItem("TEST2", 20));
            textItems.Add(new TextItem("TEST3", 20));

            var adapter = new XCarouselViewAdapter(this, textItems, 0);
            picker.Adapter = adapter;
        }
    }
}

