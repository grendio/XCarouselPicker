using UIKit;

namespace XCarousel.Touch
{
    public partial class MainViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            customCollectionView.RegisterNibForCell(CustomCollectionViewCell.Nib, CustomCollectionViewCell.Key);
            this.customCollectionView.CollectionViewLayout = new CustomFlowLayout();
            this.customCollectionView.DataSource = new CustomCollectionViewDataSource();
            this.customCollectionView.DecelerationRate = UIScrollView.DecelerationRateFast;

            //var insets = this.customCollectionView.ContentInset;
            //insets.Left = 10;
            //insets.Right = 10;
            //this.customCollectionView.ContentInset = insets;
        }
    }
}