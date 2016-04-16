using System;
using Xamarin.Forms;

using Android.Views;
using Android.Content;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(MenuSwitchCell), typeof(CustomMenuSwitchCell))]



namespace SimpleApp.Droid
{
	public class CustomMenuSwitchCell : SwitchCellRenderer
	{

		protected override global::Android.Views.View GetCellCore(Xamarin.Forms.Cell item, global::Android.Views.View convertView, ViewGroup parent, Context context)
		{
			var cell = base.GetCellCore(item, convertView, parent, context);

			var swtchCell = cell as SwitchCellView;

			if (swtchCell != null)
			{
				var swtch = swtchCell.AccessoryView as global::Android.Widget.Switch;

				if (swtch != null)
				{
					swtch.SetTextColor(Color.FromHex("#000").ToAndroid());
				}
			}
			return cell;
		}


	}
}

