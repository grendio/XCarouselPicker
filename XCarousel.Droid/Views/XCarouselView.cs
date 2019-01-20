using Android.Content;
using Android.Content.Res;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using XCarousel.Droid.Transformers;

namespace XCarousel.Droid.Views
{
    public class XCarouselView : ViewPager
    {
        public int ItemsVisible { get; set; } = 3;
        public float Divisor { get; set; }

        public XCarouselView(Context context) : base(context, null) { }

        public XCarouselView(Context context,IAttributeSet attrs) : base(context,attrs)
        {
            InitAttributes(context, attrs);
            Init();
        }

        private void InitAttributes(Context context, IAttributeSet attrs)
        {
            if(attrs != null)
            {
                TypedArray array = context.ObtainStyledAttributes(attrs, Resource.Styleable.XCarousel);
                ItemsVisible = array.GetInteger(Resource.Styleable.XCarousel_items_visible, ItemsVisible);

                switch(ItemsVisible)
                {
                    case 3:
                        var threeValue = new TypedValue();
                        Resources.GetValue(Resource.Dimension.Three_Items, threeValue, true);
                        Divisor = threeValue.Float;
                        break;
                    case 5:
                        var fiveValue = new TypedValue();
                        Resources.GetValue(Resource.Dimension.Five_Items, fiveValue, true);
                        Divisor = fiveValue.Float;
                        break;
                    case 7:
                        var sevenValue = new TypedValue();
                        Resources.GetValue(Resource.Dimension.Seven_Items, sevenValue, true);
                        break;
                    default:
                        Divisor = 3;
                        break;
                }
                array.Recycle();
            }
        }

        private void Init()
        {
            SetPageTransformer(false, new CustomPageTransformer(Context));
            SetClipChildren(false);
            SetFadingEdgeLength(0);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            int height = 0;

            for (int i = 0; i < ChildCount;i++)
            {
                var child = GetChildAt(i);
                child.Measure(widthMeasureSpec, MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified));
                var childHeight = child.MeasuredHeight;

                if (childHeight > height)
                    height = childHeight;
            }

            heightMeasureSpec = MeasureSpec.MakeMeasureSpec(height, MeasureSpecMode.Exactly);

            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            var width = MeasuredWidth;
            PageMargin = (int)(-width / Divisor);
        }

        public override PagerAdapter Adapter
        {
            get => base.Adapter;
            set
            {
                base.Adapter = value;
                OffscreenPageLimit = value.Count;
            }
        }
    }
}
