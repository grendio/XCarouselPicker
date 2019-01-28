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
            // Perform any additional setup after loading the view, typically from a nib.

            customCollectionView.RegisterNibForCell(CustomCollectionViewCell.Nib, CustomCollectionViewCell.Key);
            customCollectionView.DataSource = new CustomDataSource();
            customCollectionView.InitPrerequisites(UIColor.White, 20, 50, 100);
        }
    }
}