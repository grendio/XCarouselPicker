using System;
using System.Collections.Generic;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace XCarousel.Touch
{
    public class CustomCollectionViewDataSource : UICollectionViewDataSource
    {
        public List<int> Numbers { get; set; } = new List<int>();

        public CustomCollectionViewDataSource()
        {
            // Initialize

            // Init numbers collection
            for (int n = 0; n < 100; ++n)
            {
                Numbers.Add(n);
            }
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            // We only have one section
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            // Return the number of items
            return Numbers.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell(CustomCollectionViewCell.Key, indexPath) as CustomCollectionViewCell;

            if (cell == null)
            {
                cell = new CustomCollectionViewCell();
                var views = NSBundle.MainBundle.LoadNib(CustomCollectionViewCell.Key, cell, null);
                cell = Runtime.GetNSObject(views.ValueAt(0)) as CustomCollectionViewCell;
            }

            cell.UpdateCell(Numbers[indexPath.Row] + "");

            return cell;
        }

        public override bool CanMoveItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            // We can always move items
            return true;
        }

        public override void MoveItem(UICollectionView collectionView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
        {
            // Reorder our list of items
            var item = Numbers[(int)sourceIndexPath.Item];
            Numbers.RemoveAt((int)sourceIndexPath.Item);
            Numbers.Insert((int)destinationIndexPath.Item, item);
        }
    }
}