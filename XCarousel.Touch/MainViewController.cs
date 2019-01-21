using CoreGraphics;
using Foundation;
using UIKit;

namespace XCarousel.Touch
{
    public partial class MainViewController : UIViewController
    {
        private NSIndexPath previouslyVisibleItem;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            customCollectionView.RegisterNibForCell(CustomCollectionViewCell.Nib, CustomCollectionViewCell.Key);
            customCollectionView.CollectionViewLayout = new CustomFlowLayout();
            customCollectionView.DataSource = new CustomCollectionViewDataSource();
            customCollectionView.DecelerationEnded += CustomCollectionView_DecelerationEnded;
        }

        void CustomCollectionView_DecelerationEnded(object sender, System.EventArgs e)
        {
            var visibleRect = new CGRect(customCollectionView.ContentOffset, customCollectionView.Bounds.Size);
            var visiblePoint = new CGPoint(visibleRect.GetMidX(), visibleRect.GetMidY());
            var visibleIndexPath = customCollectionView.IndexPathForItemAtPoint(visiblePoint);

            if (previouslyVisibleItem != null && customCollectionView.CellForItem(previouslyVisibleItem) != null)
                customCollectionView.CellForItem(previouslyVisibleItem).Frame = new CGRect(customCollectionView.CellForItem(previouslyVisibleItem).Frame.Location, new CGSize(100.0, 150.0));
            customCollectionView.CellForItem(visibleIndexPath).Frame = new CGRect(customCollectionView.CellForItem(visibleIndexPath).Frame.Location, new CGSize(100.0, 170.0));
            previouslyVisibleItem = visibleIndexPath;
        }
    }
}