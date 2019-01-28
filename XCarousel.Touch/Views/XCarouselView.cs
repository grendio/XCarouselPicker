using System;
using CoreGraphics;
using UIKit;
using XCarousel.Touch.Transformers;

namespace XCarousel.Touch.Views
{
    public partial class XCarouselView : UICollectionView
    {
        private UIImage baseCellImage { get; set; }

        public UIColor FadeColor { get; set; }

        protected internal XCarouselView(IntPtr handle) : base(handle)
        {
            Scrolled += XCarouselView_Scrolled;
            ContentInset = new UIEdgeInsets(0, Frame.Width / 2, 0, -Frame.Width / 2);
        }

        public void InitPrerequisites(UIColor fadeColor, int overlapSize, nfloat cellWidth, nfloat cellHeight)
        {
            FadeColor = fadeColor;
            CollectionViewLayout = new CustomFlowLayout(overlapSize, cellWidth, cellHeight);
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
                        var path = IndexPathForCell(cell);
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
                            UpdateCellLayer(cell, new nfloat(1.2), new nfloat(1.2), int.MinValue + 2, new nfloat(0.3));
                        else if (difference == 2 || difference == -2)
                            UpdateCellLayer(cell, new nfloat(1.1), new nfloat(1.1), int.MinValue + 1, new nfloat(0.5));
                        else if (difference != 0)
                            UpdateCellLayer(cell, 1, 1, int.MinValue, new nfloat(0.7));
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
                if (subView.GetType() == typeof(UIImageView))
                {
                    var newImage = ChangeImageColor(baseCellImage, alpha, FadeColor);
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