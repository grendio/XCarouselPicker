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
            customCollectionView.DecelerationStarted += CustomCollectionView_DecelerationStarted;
        }

        public override void ViewDidAppear(bool animated)
        {
            SetSelectedCell();
            base.ViewDidAppear(animated);
        }

        void CustomCollectionView_DecelerationEnded(object sender, System.EventArgs e)
        {
            SetSelectedCell();
        }

        void CustomCollectionView_DecelerationStarted(object sender, System.EventArgs e)
        {
            DeselectCell();
        }

        void SetSelectedCell()
        {
            var visibleRect = new CGRect(customCollectionView.ContentOffset, customCollectionView.Bounds.Size);
            var visiblePoint = new CGPoint(visibleRect.GetMidX(), visibleRect.GetMidY());
            var visibleIndexPath = customCollectionView.IndexPathForItemAtPoint(visiblePoint);

            if (previouslyVisibleItem != null && customCollectionView.CellForItem(previouslyVisibleItem) != null)
                customCollectionView.CellForItem(previouslyVisibleItem).Frame = new CGRect(customCollectionView.CellForItem(previouslyVisibleItem).Frame.Location, new CGSize(100.0, 150.0));
            customCollectionView.CellForItem(visibleIndexPath).Frame = new CGRect(customCollectionView.CellForItem(visibleIndexPath).Frame.Location, new CGSize(100.0, 170.0));
            previouslyVisibleItem = visibleIndexPath;

            customCollectionView.SelectItem(visibleIndexPath, true, UICollectionViewScrollPosition.None);
        }

        void DeselectCell()
        {
            if (previouslyVisibleItem != null && customCollectionView.CellForItem(previouslyVisibleItem) != null)
                customCollectionView.CellForItem(previouslyVisibleItem).Frame = new CGRect(customCollectionView.CellForItem(previouslyVisibleItem).Frame.Location, new CGSize(100.0, 150.0));
            previouslyVisibleItem = null;
        }
    }
}