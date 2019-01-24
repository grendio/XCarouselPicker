using System;
using CoreGraphics;
using UIKit;

namespace XCarousel.Touch
{
    public class CustomFlowLayout : UICollectionViewFlowLayout
    {
        public CustomFlowLayout(nfloat width, nfloat height)
        {
            ItemSize = new CGSize(width, height);
            ScrollDirection = UICollectionViewScrollDirection.Horizontal;
        }
    }
}