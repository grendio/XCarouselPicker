using CoreGraphics;
using Foundation;
using UIKit;

namespace XCarousel.Touch
{
    public class CustomCollectionViewDelegate : UICollectionViewDelegateFlowLayout
    {
        public override void WillDisplayCell(UICollectionView collectionView, UICollectionViewCell cell, NSIndexPath indexPath)
        {
            var cells = collectionView.VisibleCells;

            var visibleRect = new CGRect(collectionView.ContentOffset, collectionView.Bounds.Size);
            var visiblePoint = new CGPoint(visibleRect.GetMidX(), visibleRect.GetMidY());
            var visibleIndexPath = collectionView.IndexPathForItemAtPoint(visiblePoint);

            if(collectionView.CellForItem(visibleIndexPath) != null)
            collectionView.CellForItem(visibleIndexPath).Frame = new CGRect(collectionView.CellForItem(visibleIndexPath).Frame.Location, new CGSize(100.0, 170.0));
        }
    }
}