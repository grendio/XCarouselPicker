using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using static Android.Support.V4.View.ViewPager;

namespace XCarousel.Droid.Transformers
{
    public class CustomPageTransformer : Java.Lang.Object,IPageTransformer
    {
        private ViewPager viewPager;

        public CustomPageTransformer(Context context)
        {
        }

        public IntPtr Handle => base.Handle;

        public void Dispose()
        {
            base.Dispose();
        }

        public void TransformPage(View page, float position)
        {
            if(viewPager == null)
            {
                viewPager = page.Parent as ViewPager;
            }
            page.ScaleX = 1 - Math.Abs(position);
            page.ScaleY = 1 - Math.Abs(position);
            page.Elevation = 1 - Math.Abs(position);
            page.TranslationZ = 1 - Math.Abs(position);

            var img = page.FindViewById<ImageView>(Resource.Id.imageView);

            var color = Color.ParseColor("#d3b49b");

            if (Math.Abs(position) >= 0.4)
            { 
                color.A = 255;
            }
            else
            {
                color.A = (byte) (580 * Math.Abs(position));
            }
            ImageViewCompat.SetImageTintMode(img, PorterDuff.Mode.SrcAtop);
            ImageViewCompat.SetImageTintList(img, ColorStateList.ValueOf(color));
        }
    }
}
