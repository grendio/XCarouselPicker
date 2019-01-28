using System;
using CoreGraphics;
using UIKit;

namespace XCarousel.Touch.Transformers
{
    public class CustomFlowLayout : UICollectionViewFlowLayout
    {
        private int overlapSize;

        public CustomFlowLayout(int overlapSize, nfloat width, nfloat height)
        {
            this.overlapSize = overlapSize;
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
                    xPosition -= overlapSize * attributes.IndexPath.Row;
                    attributes.ZIndex = numberOfItems - attributes.IndexPath.Row; //Other cells below the first one
                }

                attributes.Center = new CGPoint(xPosition, yPosition);
            }

            return attributesArray;
        }
    }
}