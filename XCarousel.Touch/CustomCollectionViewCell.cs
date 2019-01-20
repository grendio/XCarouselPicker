using System;
using Foundation;
using UIKit;

namespace XCarousel.Touch
{
    public partial class CustomCollectionViewCell : UICollectionViewCell
    {
        public static readonly UINib Nib = UINib.FromName("CustomCollectionViewCell", NSBundle.MainBundle);
        public static readonly NSString Key = new NSString("CustomCollectionViewCell");

        public CustomCollectionViewCell() : base()
        {
        }

        public CustomCollectionViewCell(IntPtr handle) : base(handle)
        {
        }

        public void UpdateCell(string text)
        {
            lbCustom.Text = text;
        }
    }
}