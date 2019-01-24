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
                    middleCell.Transform = CGAffineTransform.MakeScale(1, new nfloat(1.6));
                }

                foreach (var cell in cells)
                {
                    cell.ContentView.Alpha = 1;
                    var path = customCollectionView.IndexPathForCell(cell);
                    var difference = path.LongRow - visibleIndexPath.LongRow;
                    if (difference == 1 || difference == -1)
                    {
                        cell.Transform = CGAffineTransform.MakeScale(1, new nfloat(1.4));
                        cell.ContentView.Alpha = new nfloat(0.7);
                    }
                    else if (difference == 2 || difference == -2)
                    {
                        cell.Transform = CGAffineTransform.MakeScale(1, new nfloat(1.2));
                        cell.ContentView.Alpha = new nfloat(0.5);
                    }
                    else if (difference != 0)
                    {
                        cell.Transform = CGAffineTransform.MakeScale(1, 1);
                        cell.ContentView.Alpha = new nfloat(0.2);
                    }
                }
            }
        }
    }
}