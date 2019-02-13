using System;
using UIKit;
using XCarousel.Touch.Transformers;

namespace XCarousel.Touch.Views
{
    public partial class XCarouselView : UICollectionView
    {
        protected internal XCarouselView(IntPtr handle) : base(handle)
        {
            ContentInset = new UIEdgeInsets(0, Frame.Width / 2, 0, -Frame.Width / 2);
        }

        public void InitPrerequisites(UIColor fadeColor, int overlapSize, nfloat cellWidth, nfloat cellHeight)
        {
            CollectionViewLayout = new CustomFlowLayout(overlapSize, cellWidth, cellHeight);
            Delegate = new CustomViewDelegateFlowLayout(fadeColor);
        }
    }
}