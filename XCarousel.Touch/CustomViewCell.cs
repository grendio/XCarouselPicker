using System;
using UIKit;

namespace XCarousel.Touch
{
    public partial class CustomViewCell : UITableViewCell
    {
        public CustomViewCell() : base()
        {
        }

        public CustomViewCell(IntPtr handle) : base(handle)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
        }

        public void UpdateCell(string text)
        {
            lbCustomValue.Text = text;
        }
    }
}