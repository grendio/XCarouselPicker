using System.Collections.Generic;
using UIKit;

namespace XCarousel.Touch
{
    public partial class MainViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var tableData = new List<string>();

            tableData.Add("Vegetables");
            tableData.Add("Fruits");
            tableData.Add("Flower Buds");
            tableData.Add("Legumes");
            tableData.Add("Bulbs");
            tableData.Add("Tubers");

            tbCustom.Source = new CustomTableSource(tableData);
            customCollectionView.RegisterNibForCell(CustomCollectionViewCell.Nib, CustomCollectionViewCell.Key);
            customCollectionView.DataSource = new CustomCollectionViewDataSource();
        }
    }
}