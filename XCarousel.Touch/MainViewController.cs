using UIKit;

namespace XCarousel.Touch
{
    public partial class MainViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            customCollectionView.RegisterNibForCell(CustomCollectionViewCell.Nib, CustomCollectionViewCell.Key);
            customCollectionView.CollectionViewLayout = new CustomFlowLayout();
            customCollectionView.Delegate = new CustomCollectionViewDelegate();
            customCollectionView.DataSource = new CustomCollectionViewDataSource();
            customCollectionView.DecelerationRate = UIScrollView.DecelerationRateFast;
            customCollectionView.AllowsMultipleSelection = true;
        }
    }
}