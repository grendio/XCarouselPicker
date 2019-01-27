using System;
using Foundation;
using UIKit;

namespace XCarousel.Touch.Sample
{
    public partial class CustomCollectionViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("CustomCollectionViewCell");
        public static readonly UINib Nib;

        static CustomCollectionViewCell()
        {
            Nib = UINib.FromName("CustomCollectionViewCell", NSBundle.MainBundle);
        }

        protected CustomCollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void UpdateCell(string text)
        {
            lbCustom.Text = text;
        }
    }
}