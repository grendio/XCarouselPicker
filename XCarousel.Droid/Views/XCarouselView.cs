using System.Collections.Generic;
using Android.Content;
using Android.Content.Res;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using XCarousel.Droid.Adapters;
using XCarousel.Droid.Interfaces;
using XCarousel.Droid.Transformers;

namespace XCarousel.Droid.Views
{
    public class XCarouselView : ViewPager
    {
        public int Selected { get; set; }

        public string FadeColor 
        { 
            get
            {
                return pageTransformer.FadeColor;
            }
            set
            {
                pageTransformer.FadeColor = value;
            }
        }

        CustomPageTransformer pageTransformer;

        public List<PickerItem> Items
        {
            get
            {
                return ((XCarouselViewAdapter)Adapter).Items;
            }
            set
            {
                ((XCarouselViewAdapter)Adapter).Items = value;
                OffscreenPageLimit = value.Count;
            }
        }

        public int ItemsVisible { get; set; } = 3;

        public float Divisor { get; set; }

        public XCarouselView(Context context) : base(context, null) { }

        public XCarouselView(Context context,IAttributeSet attrs) : base(context,attrs)
        {
            InitAttributes(context, attrs);
            Init();
            PageSelected += (sender, e) => { Selected = e.Position; };
        }

        private void InitAttributes(Context context, IAttributeSet attrs)
        {
            if(attrs != null)
            {
                TypedArray array = context.ObtainStyledAttributes(attrs, Resource.Styleable.XCarousel);
                ItemsVisible = array.GetInteger(Resource.Styleable.XCarousel_itemsVisible, ItemsVisible);

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
            pageTransformer = new CustomPageTransformer(Context);

            SetPageTransformer(false, pageTransformer);
            Adapter = new XCarouselViewAdapter(Context, null, 0);

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
            PageMargin = (int)(-width / Divisor) - 265;
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
