using System;
using System.Collections.Generic;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace XCarousel.Touch.Sample
{
    public class CustomDataSource : UICollectionViewSource
    {
        public List<int> Numbers { get; set; } = new List<int>();

        public CustomDataSource()
        {
            // Initialize

            // Init numbers collection
            for (int n = 0; n < 20; ++n)
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
                var views = NSBundle.MainBundle.LoadNib(CustomCollectionViewCell.Key, cell, null);
                cell = Runtime.GetNSObject(views.ValueAt(0)) as CustomCollectionViewCell;
            }

            cell.UpdateCell(Numbers[indexPath.Row] + "");

            return cell;
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            //base.ItemSelected(collectionView, indexPath);
        }
    }
}
