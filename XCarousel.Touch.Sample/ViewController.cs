using Foundation;
using UIKit;

namespace XCarousel.Touch.Sample
{
    public partial class ViewController : UIViewController
    {
        public ViewController() : base("ViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            customCollectionView.RegisterNibForCell(CustomCollectionViewCell.Nib, CustomCollectionViewCell.Key);

            var collectionViewSource = new CustomDataSource();
            customCollectionView.Source = collectionViewSource;
            customCollectionView.InitPrerequisites(UIColor.White, 20, 50, 100);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            var indexPath = NSIndexPath.FromItemSection(9, 0);
            customCollectionView.ScrollToItem(indexPath, UICollectionViewScrollPosition.CenteredHorizontally, true);
        }
    }
}