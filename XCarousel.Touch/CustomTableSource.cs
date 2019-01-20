using System;
using System.Collections.Generic;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace XCarousel.Touch
{
    public class CustomTableSource : UITableViewSource
    {
        List<string> tableItems = new List<string>();

        public CustomTableSource(List<string> items)
        {
            tableItems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("CustomViewCell") as CustomViewCell;

            if (cell == null)
            {
                cell = new CustomViewCell();
                var views = NSBundle.MainBundle.LoadNib("CustomViewCell", cell, null);
                cell = Runtime.GetNSObject(views.ValueAt(0)) as CustomViewCell;
            }

            cell.UpdateCell(tableItems[indexPath.Row]);

            return cell;
        }
    }
}