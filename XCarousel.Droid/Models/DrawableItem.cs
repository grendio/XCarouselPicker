using System;
using XCarousel.Droid.Interfaces;

namespace XCarousel.Droid.Models
{
    public class DrawableItem : PickerItem
    {
        private int drawable;

        public string Text { get => null; set => throw new NotImplementedException(); }
        public int Drawable { get => drawable; set => drawable = value; }
        public bool HasDrawable { get => true; set => throw new NotImplementedException(); }

        public DrawableItem(int drawable)
        {
            Drawable = drawable;
        }
    }
}
