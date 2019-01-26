using UIKit;

namespace XCarousel.Touch
{
    public partial class MainViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            customCollectionView.RegisterNibForCell(CustomCollectionViewCell.Nib, CustomCollectionViewCell.Key);
            customCollectionView.DataSource = new CustomCollectionViewDataSource();
        }
    }
}