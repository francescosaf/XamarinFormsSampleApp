using System;
using Xamarin.Forms;

using UIKit;
using Xamarin.Forms.Platform.iOS;

using CoreGraphics;
using ObjCRuntime;
using SampleApp;
using SampleApp.iOS;


[assembly: ExportRendererAttribute(typeof(ViewCellExecution), typeof(NativeIOSCellRenderer))]
[assembly: ExportRendererAttribute(typeof(ViewCellArrival), typeof(NativeIOSCellRenderer))]
[assembly: ExportRendererAttribute(typeof(ViewCellBreak), typeof(NativeIOSCellRenderer))]
[assembly: ExportRendererAttribute(typeof(ViewCellDepot), typeof(NativeIOSCellRenderer))]
[assembly: ExportRenderer(typeof(ListView), typeof(CustomListViewRenderer))]

namespace SampleApp.iOS
{
	public class NativeIOSCellRenderer:ViewCellRenderer
	{
		public override UIKit.UITableViewCell GetCell (Xamarin.Forms.Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
		{
			var cell= base.GetCell (item, reusableCell,tv);

			tv.SeparatorColor = UIColor.DarkGray;
			tv.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
			/*
			if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
				tv.CellLayoutMarginsFollowReadableWidth = false;
			tv.SeparatorInset = UIEdgeInsets.Zero;
			tv.PreservesSuperviewLayoutMargins = false;
			tv.LayoutMargins = UIEdgeInsets.Zero;
			*/
			cell.LayoutMargins = UIEdgeInsets.Zero;
			cell.SeparatorInset = UIEdgeInsets.Zero;

			return cell;
		} 
	}


	public class CustomMenuSwitchCell : SwitchCellRenderer
	{
		public override UIKit.UITableViewCell GetCell (Xamarin.Forms.Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
		{
			var menuCell = item as SwitchCell;

			var cell = base.GetCell(menuCell,reusableCell, tv);

			cell.TextLabel.Text = menuCell.Text;
			//cell.TextLabel.Font = UIFont.BoldSystemFontOfSize (16f);
			cell.TextLabel.TextColor = UIColor.White; // CUSTOM COLOR...
			//cell.BackgroundColor = UIColor.Clear;

			return cell;
		}
	}

	public class CustomListViewRenderer : ListViewRenderer
	{
		protected override void UpdateNativeWidget ()
		{
			// remove extra lines in a table
			Control.TableFooterView = new UIView (CGRect.Empty);

			base.UpdateNativeWidget ();

			// fix the default insets on table rows
			if (Control.RespondsToSelector (new Selector ("setSeparatorInset:"))) {
				Control.SeparatorInset = UIEdgeInsets.Zero;
			}
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)||UIDevice.CurrentDevice.CheckSystemVersion(9, 0) ) {
				Control.LayoutMargins = UIEdgeInsets.Zero;
			}
		}
	}

}
