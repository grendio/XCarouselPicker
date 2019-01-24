using System;
using CoreGraphics;
using UIKit;

namespace XCarousel.Touch
{
    public partial class MainViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            customCollectionView.RegisterNibForCell(CustomCollectionViewCell.Nib, CustomCollectionViewCell.Key);
            customCollectionView.CollectionViewLayout = new CustomFlowLayout(50, 100);
            customCollectionView.Frame = new CGRect(customCollectionView.Frame.Location, new CGSize(View.Frame.Size.Width, 100));
            customCollectionView.DataSource = new CustomCollectionViewDataSource();
            customCollectionView.Scrolled += CustomCollectionView_Scrolled;
        }

        void CustomCollectionView_Scrolled(object sender, EventArgs e)
        {
            var cells = customCollectionView.VisibleCells;

            var visibleRect = new CGRect(customCollectionView.ContentOffset, customCollectionView.Bounds.Size);
            var visiblePoint = new CGPoint(visibleRect.GetMidX(), visibleRect.GetMidY());
            var visibleIndexPath = customCollectionView.IndexPathForItemAtPoint(visiblePoint);

            if (visibleIndexPath != null)
            {
                if (customCollectionView.CellForItem(visibleIndexPath) != null)
                {
                    var middleCell = customCollectionView.CellForItem(visibleIndexPath);
                    middleCell.Transform = CGAffineTransform.MakeScale(1, new nfloat(1.5));
                }
            }
        }
    }
}