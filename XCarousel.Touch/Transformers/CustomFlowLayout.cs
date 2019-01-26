using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace XCarousel.Touch.Transformers
{
    public class CustomFlowLayout : UICollectionViewFlowLayout
    {
        public CustomFlowLayout(nfloat width, nfloat height)
        {
            ItemSize = new CGSize(width, height);
            ScrollDirection = UICollectionViewScrollDirection.Horizontal;
        }

        public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CGRect rect)
        {
            var attributesArray = base.LayoutAttributesForElementsInRect(rect);
            var numberOfItems = CollectionView.NumberOfItemsInSection(0);

            foreach (var attributes in attributesArray)
            {
                var xPosition = attributes.Center.X;
                var yPosition = attributes.Center.Y;

                if (attributes.IndexPath.Row == 0)
                    attributes.ZIndex = int.MaxValue; // Put the first cell on top of the stack
                else
                {
                    xPosition -= 20 * attributes.IndexPath.Row;
                    attributes.ZIndex = numberOfItems - attributes.IndexPath.Row; //Other cells below the first one
                }

                attributes.Center = new CGPoint(xPosition, yPosition);
            }

            return attributesArray;
        }

        public override UICollectionViewLayoutAttributes LayoutAttributesForItem(NSIndexPath indexPath)
        {
            return LayoutAttributesForItem(indexPath);
        }
    }
}