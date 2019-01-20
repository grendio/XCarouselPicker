using System;
using Android.Content;
using Android.Support.V4.View;
using Android.Views;
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
        }
    }
}
