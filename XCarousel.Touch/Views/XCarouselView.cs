using System;
using CoreGraphics;
using UIKit;
using XCarousel.Touch.Transformers;

namespace XCarousel.Touch.Views
{
    public partial class XCarouselView : UICollectionView
    {
        protected internal XCarouselView(IntPtr handle) : base(handle)
        {
            //TODO Give those values as parameter somehow
            CollectionViewLayout = new CustomFlowLayout(50, 100);
            Scrolled += XCarouselView_Scrolled;
            ContentInset = new UIEdgeInsets(0, Frame.Width / 2, 0, -Frame.Width / 2);
        }

        /// <summary>
        /// Responsible of everything around the Elevation, Fade and cell overlapping.
        /// </summary>
        private void XCarouselView_Scrolled(object sender, EventArgs e)
        {
            var visibleRect = new CGRect(ContentOffset, Bounds.Size);
            var visiblePoint = new CGPoint(visibleRect.GetMidX(), visibleRect.GetMidY());
            var visibleIndexPath = IndexPathForItemAtPoint(visiblePoint);

            if (visibleIndexPath != null)
            {
                Animate(0.3, 0.0, UIViewAnimationOptions.AllowUserInteraction, () =>
                {
                    if (CellForItem(visibleIndexPath) != null)
                    {
                        var middleCell = CellForItem(visibleIndexPath);
                        middleCell.Transform = CGAffineTransform.MakeScale(new nfloat(1.3), new nfloat(1.3));
                    }

                    foreach (var cell in VisibleCells)
                    {
                        cell.ContentView.Alpha = 1;
                        var path = IndexPathForCell(cell);
                        var difference = path.LongRow - visibleIndexPath.LongRow;

                        if (difference == 0)
                        {
                            cell.Layer.ZPosition = int.MaxValue;
                        }

                        if (difference == 1 || difference == -1)
                        {
                            cell.Transform = CGAffineTransform.MakeScale(new nfloat(1.2), new nfloat(1.2));
                            cell.Layer.ZPosition = int.MinValue + 2;
                            //TODO cell.ContentView.Alpha = new nfloat(0.7);
                        }
                        else if (difference == 2 || difference == -2)
                        {
                            cell.Transform = CGAffineTransform.MakeScale(new nfloat(1.1), new nfloat(1.1));
                            cell.Layer.ZPosition = int.MinValue + 1;
                            //TODO cell.ContentView.Alpha = new nfloat(0.5); 
                        }
                        else if (difference != 0)
                        {
                            cell.Transform = CGAffineTransform.MakeScale(1, 1);
                            cell.Layer.ZPosition = int.MinValue;
                            //TODO cell.ContentView.Alpha = new nfloat(0.2);
                        }
                    }
                }, null);
            }
        }
    }
}