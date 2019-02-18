using System;
using System.Linq;
using CoreGraphics;
using UIKit;

namespace XCarousel.Touch.Transformers
{
    public class CustomViewDelegateFlowLayout : UICollectionViewDelegateFlowLayout
    {
        private UIImage baseCellImage { get; set; }
        private UIColor fadeColor { get; set; }

        public CustomViewDelegateFlowLayout(UIColor fadeColor)
        {
            this.fadeColor = fadeColor;
        }

        public override void Scrolled(UIScrollView scrollView)
        {
            var collectionView = scrollView as UICollectionView;

            var visibleRect = new CGRect(collectionView.ContentOffset, collectionView.Bounds.Size);
            var visiblePoint = new CGPoint(visibleRect.GetMidX(), visibleRect.GetMidY());
            var visibleIndexPath = collectionView.IndexPathForItemAtPoint(visiblePoint);

            if (visibleIndexPath != null)
            {
                UIView.Animate(0.3, 0.0, UIViewAnimationOptions.AllowUserInteraction, () =>
                {
                    if (collectionView.CellForItem(visibleIndexPath) != null)
                    {
                        var middleCell = collectionView.CellForItem(visibleIndexPath);
                        middleCell.Transform = CGAffineTransform.MakeScale(new nfloat(1.3), new nfloat(1.3));
                        if (collectionView.DataSource != null)
                            (collectionView.DataSource as UICollectionViewSource).ItemSelected(collectionView, visibleIndexPath);
                    }

                    foreach (var cell in collectionView.VisibleCells)
                    {
                        var path = collectionView.IndexPathForCell(cell);
                        var difference = path.LongRow - visibleIndexPath.LongRow;

                        if (difference == 0)
                        {
                            cell.Layer.ZPosition = int.MaxValue;

                            foreach (var subView in cell.ContentView.Subviews)
                            {
                                if (subView.GetType() == typeof(UIImageView))
                                {
                                    if (baseCellImage == null)
                                        baseCellImage = (subView as UIImageView).Image;
                                    (subView as UIImageView).Image = baseCellImage;
                                }
                            }
                        }

                        if (difference == 1 || difference == -1)
                            UpdateCellLayer(cell, new nfloat(1.3), new nfloat(1.3), int.MinValue + 3, new nfloat(0.3));
                        else if (difference == 2 || difference == -2)
                            UpdateCellLayer(cell, new nfloat(1.2), new nfloat(1.2), int.MinValue + 2, new nfloat(0.5));
                        else if (difference == 3 || difference == -3)
                            UpdateCellLayer(cell, new nfloat(1.1), new nfloat(1.1), int.MinValue + 1, new nfloat(0.7));
                        else if (difference != 0)
                            UpdateCellLayer(cell, 1, 1, int.MinValue, 1);
                    }
                }, null);
            }
        }

        private void UpdateCellLayer(UICollectionViewCell cell, nfloat sx, nfloat sy, int zPosition, nfloat alpha)
        {
            cell.Transform = CGAffineTransform.MakeScale(sx, sy);
            cell.Layer.ZPosition = zPosition;

            foreach (var subView in cell.ContentView.Subviews)
            {
                if (subView.GetType() == typeof(UIImageView) && baseCellImage != null)
                {
                    var newImage = ChangeImageColor(baseCellImage, alpha, fadeColor);
                    (subView as UIImageView).Image = newImage;
                }
            }
        }

        private UIImage ChangeImageColor(UIImage image, nfloat alpha, UIColor color)
        {
            var alphaColor = color.ColorWithAlpha(alpha);

            UIGraphics.BeginImageContextWithOptions(image.Size, false, UIScreen.MainScreen.Scale);

            var context = UIGraphics.GetCurrentContext();
            alphaColor.SetFill();

            context.TranslateCTM(0, image.Size.Height);
            context.ScaleCTM(new nfloat(1.0), new nfloat(-1.0));
            context.SetBlendMode(CGBlendMode.Lighten);

            var rect = new CGRect(0, 0, image.Size.Width, image.Size.Height);
            context.DrawImage(rect, image.CGImage);

            context.SetBlendMode(CGBlendMode.SourceAtop);
            context.AddRect(rect);
            context.DrawPath(CGPathDrawingMode.Fill);

            image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return image;
        }
    }
}