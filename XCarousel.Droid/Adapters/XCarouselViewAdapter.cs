using System.Collections.Generic;
using Android.Content;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using XCarousel.Droid.Interfaces;
using XCarousel.Droid.Models;

namespace XCarousel.Droid.Adapters
{
    public class XCarouselViewAdapter : PagerAdapter
    {
        List<PickerItem> Items { get; set; } = new List<PickerItem>();

        public Context Context { get; set; }

        public int Drawable { get; set; }
        public int TextColor { get; set; } = 0;
        public override int Count => Items.Count;

        public XCarouselViewAdapter(Context context, List<PickerItem> items, int drawable)
        {
            Context = context;
            Drawable = drawable;
            Items = items;

            if (Drawable == 0)
                Drawable = Resource.Layout.Page;
        }


        public override Object InstantiateItem(ViewGroup container, int position)
        {
            var view = LayoutInflater.From(Context).Inflate(Drawable, null);
            var imageView = view.FindViewById<ImageView>(Resource.Id.imageView);
            var textView = view.FindViewById<TextView>(Resource.Id.textView);

            var pickerItem = Items[position];
            imageView.Visibility = ViewStates.Visible;

            if(pickerItem.HasDrawable)
            {
                imageView.Visibility = ViewStates.Visible;
                textView.Visibility = ViewStates.Gone;
                imageView.SetImageResource(pickerItem.Drawable);
            }
            else
            {
                if(pickerItem.Text != null)
                {
                    imageView.Visibility = ViewStates.Gone;
                    textView.Visibility = ViewStates.Visible;
                    textView.Text = pickerItem.Text;

                    //if(TextColor != 0)
                    //{
                    //    textView.SetTextColor(TextColor);
                    //}

                    var textSize = (pickerItem as TextItem).TextSize;

                    if (textSize != 0)
                        textView.TextSize = DpToPx((pickerItem as TextItem).TextSize);
                }
            }

            view.Tag = position;
            container.AddView(view);
            return view;
        }

        public override void DestroyItem(ViewGroup container, int position, Object @object)
        {
            container.RemoveView(@object as View);
        }

        public override bool IsViewFromObject(View view, Object @object)
        {
            return view == @object;
        }

        private int DpToPx(int dp)
        {
            var displayMetrics = Context.Resources.DisplayMetrics;
            return Math.Round(dp * (displayMetrics.Xdpi / (float) DisplayMetricsDensity.Default));
        }
    }
}
