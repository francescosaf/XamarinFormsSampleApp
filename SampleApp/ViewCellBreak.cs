using System;
using Xamarin.Forms;

namespace SampleApp
{
	public class ViewCellBreak : ViewCell
	{

		Label label2;
		public RowDefinition _detailsRow;
		public double _detailsRowHeight=50;
		private Animation _animation;
		public static ListView temp;
		//private string stepType;
		public static int i = 0;
		public Grid grid;
		public Grid gridTap;
		public Grid gridLeftCell;
		public Image iconmap= new Image { Aspect = Aspect.AspectFit };

		public ViewCellBreak ()
		{
			grid = new Grid {
				Padding = new Thickness(0, Device.OnPlatform(0, 0, 0), 0, 0)	,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowSpacing=0,
			};
			// Define columns
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50, GridUnitType.Absolute) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Absolute) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30, GridUnitType.Absolute) });
			grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
			grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
			grid.RowDefinitions.Add(_detailsRow=new RowDefinition { Height = 0 });


			gridLeftCell = new Grid {
				Padding = new Thickness(0, Device.OnPlatform(0, 0, 0), 0, 0)	,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowSpacing=0,
				ColumnSpacing=0
			};
			gridLeftCell.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30, GridUnitType.Star) });
			gridLeftCell.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) });
			gridLeftCell.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Absolute) });
			gridLeftCell.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) });

			gridTap= new Grid {
				Padding = new Thickness(30, Device.OnPlatform(5, 5, 5), 5, 5)	,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowSpacing=0,
				ColumnSpacing=5,
				BackgroundColor=AppStyle.ColorBlue
			};
			gridTap.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
			gridTap.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
			gridTap.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
			gridTap.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Absolute) });
			gridTap.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(25, GridUnitType.Absolute) });
			gridTap.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });


			i++;
			View = grid;
			/////-------------- IMPLEMENTATION ------------

			gridLeftCell.BackgroundColor = AppStyle.ColorMyGray;

			var label1 = new Label {
				TextColor = AppStyle.ColorBlue,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) ,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				LineBreakMode = LineBreakMode.TailTruncation,
				BackgroundColor=AppStyle.ColorMyGray
			};

			label1.SetBinding<Step> (Label.TextProperty, myvm => myvm.StartSec, BindingMode.Default,
				new SecondsToHoursMinutesValueConverter(), null);
			// Columns 0, row 1
			gridLeftCell.Children.Add (label1, 0, 1, 0, 1);


			// Columns 0, row 1
			gridLeftCell.Children.Add (HorLine (Color.Gray.MultiplyAlpha (.5), 25), 0, 1, 1, 2);

			var label4 = new Label {
				TextColor =AppStyle.ColorBlue,
				BackgroundColor=AppStyle.ColorMyGray,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) ,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				LineBreakMode = LineBreakMode.TailTruncation,

			};

			label4.SetBinding<Step> (Label.TextProperty, myvm => myvm.EndSec, BindingMode.Default,
				new SecondsToHoursMinutesValueConverter(), null);
			// Columns 0, row 1
			gridLeftCell.Children.Add(label4, 0, 1, 2, 3);

			// Columns 0, row 1-2
			grid.Children.Add (gridLeftCell, 0, 1, 0, 2);


			Label labelBreak = new Label () { Text = "Break", 					
				TextColor = AppStyle.ColorBlue,
				BackgroundColor=AppStyle.ColorMyGray,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				LineBreakMode = LineBreakMode.TailTruncation };
			grid.Children.Add (labelBreak, 1, 4, 0, 2);
			grid.BackgroundColor = AppStyle.ColorMyGray;
		}

		private BoxView VertLine (Color color,double height)
		{
			return  new BoxView () {
				Color = color,
				WidthRequest = 1,
				HeightRequest = height,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
		}

		private BoxView HorLine (Color color,double width)
		{
			return  new BoxView () {
				Color = color,
				WidthRequest = width,
				HeightRequest = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
		}
	}
}

