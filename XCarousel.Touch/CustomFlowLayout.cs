using System;
using CoreGraphics;
using UIKit;

namespace XCarousel.Touch
{
    public class CustomFlowLayout : UICollectionViewFlowLayout
    {
        public CustomFlowLayout()
        {
            this.ItemSize = new CGSize(50, 50);
            this.ScrollDirection = UICollectionViewScrollDirection.Horizontal;
        }

        CGPoint mostRecentOffset = new CGPoint();

        public override CGPoint TargetContentOffset(CGPoint proposedContentOffset, CGPoint scrollingVelocity)
        {
            if (scrollingVelocity.X == 0)
            {
                return mostRecentOffset;
            }

            var cv = this.CollectionView;
            if (cv != null)
            {
                var cvBounds = this.CollectionView.Bounds;
                var halfWidth = cvBounds.Size.Width * 0.5f;
                var attributesForVisibleCells = this.LayoutAttributesForElementsInRect(cvBounds);
                if (attributesForVisibleCells != null)
                {
                    if (proposedContentOffset.X == -(cv.ContentInset.Left))
                    {
                        return proposedContentOffset;
                    }

                    UICollectionViewLayoutAttributes candidateAttributes = null;
                    foreach (var attributes in attributesForVisibleCells)
                    {
                        if (attributes.RepresentedElementCategory != UICollectionElementCategory.Cell)
                        {
                            continue;
                        }

                        if ((attributes.Center.X == 0) || (attributes.Center.X > (cv.ContentOffset.X + halfWidth) && scrollingVelocity.X < 0))
                        {
                            continue;
                        }
                        candidateAttributes = attributes;
                    }

                    if (candidateAttributes == null)
                    {
                        return mostRecentOffset;
                    }

                    return mostRecentOffset = new CGPoint(candidateAttributes.Center.X - halfWidth, proposedContentOffset.Y);
                }
            }

            return mostRecentOffset = base.TargetContentOffset(proposedContentOffset, scrollingVelocity);
        }
    }
}