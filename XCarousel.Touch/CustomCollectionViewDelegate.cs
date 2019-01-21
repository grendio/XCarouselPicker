using CoreGraphics;
using Foundation;
using UIKit;

namespace XCarousel.Touch
{
    public class CustomCollectionViewDelegate : UICollectionViewDelegateFlowLayout
    {
        public override void WillDisplayCell(UICollectionView collectionView, UICollectionViewCell cell, NSIndexPath indexPath)
        {
            if (indexPath.Row == 2)
                cell.Frame = new CGRect(cell.Frame.Location, new CGSize(120.0, 170.0));
        }
    }
}