// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XCarousel.Touch
{
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView customCollectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tbCustom { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (customCollectionView != null) {
                customCollectionView.Dispose ();
                customCollectionView = null;
            }

            if (tbCustom != null) {
                tbCustom.Dispose ();
                tbCustom = null;
            }
        }
    }
}