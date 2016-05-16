using System;
using Xamarin.Forms;

namespace SampleApp
{
	public class ViewCellExecution : ViewCell
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

		public ViewCellExecution ()
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

			//VoloMobileBase.LogDebug (" ----> " +i +" "+StepCountText);
			i++;
			View = grid;

			/////-------------- IMPLEMENTATION ------------

			gridLeftCell.BackgroundColor=AppStyle.ColorGreen;

			var label1 = new Label {
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				LineBreakMode = LineBreakMode.TailTruncation,
				BackgroundColor = AppStyle.ColorGreen
			};
			label1.SetBinding (Label.TextProperty, "DisplayLabel");
			// Columns 0, row 0
			gridLeftCell.Children.Add (label1, 0, 1, 0, 1);

			// Columns 0, row 1
			gridLeftCell.Children.Add (HorLine (Color.Green.MultiplyAlpha (.5), 25), 0, 1, 1, 2);

			var label4 = new Label {
				TextColor =Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) ,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				LineBreakMode = LineBreakMode.TailTruncation,
				BackgroundColor=AppStyle.ColorGreen
			};

			label4.SetBinding<Step> (Label.TextProperty, myvm => myvm.StartSec, BindingMode.Default,
				new SecondsToHoursMinutesValueConverter(), null);
			// Columns 0, row 2
			gridLeftCell.Children.Add(label4, 0, 1, 2, 3);



			// Columns 0, row 1-2
			grid.Children.Add (gridLeftCell, 0, 1, 0, 2);


			this.Tapped += onTap;


			label2 = new Label {
				FontAttributes = FontAttributes.Bold,
				TextColor = AppStyle.ColorTextList,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				HorizontalTextAlignment = TextAlignment.Start,
				VerticalTextAlignment = TextAlignment.Start,
				LineBreakMode = LineBreakMode.TailTruncation
			};
			label2.SetBinding (Label.TextProperty, "OrderStep.Name");

			// Columns 1, row 0
			grid.Children.Add (label2, 1, 2, 0, 1);

			grid.Children.Add (VertLine (Color.Gray.MultiplyAlpha (.5), 40), 2, 3, 0, 2);



			// Columns 4, row 0,2
			//grid.Children.Add (DetailStepPage.iconmap, 3, 4, 0, 2);
			var tapImageRecognizer= new TapGestureRecognizer();
			tapImageRecognizer.Tapped += (s, e) => {
				var row = (int)((BindableObject)s).GetValue(Grid.RowProperty);
				var column = (int)((BindableObject)s).GetValue(Grid.ColumnProperty);
				var itemStemp = (Step)BindingContext;
			};


			iconmap.Source=ImageSource.FromFile ("icon_map.png");
			iconmap.GestureRecognizers.Add (tapImageRecognizer);

			// Columns 4, row 0,2
			grid.Children.Add (iconmap, 3, 4, 0, 2);

			var label5 = new Label {
				TextColor =  AppStyle.ColorTextList,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				HorizontalTextAlignment = TextAlignment.Start,
				VerticalTextAlignment = TextAlignment.Center,
				LineBreakMode = LineBreakMode.WordWrap
			};
			label5.SetBinding (Label.TextProperty, "OrderStep.Location.Address");
			// Columns 1, row 1
			grid.Children.Add (label5, 1, 2, 1, 2);




		}

		void onTap (object sender, EventArgs e)
		{

			var itemStemp = (Step)BindingContext;
			//if (itemStemp!=null)
			//VoloMobileBase.LogDebug (" ----> " + itemStemp.Type);
			//else
			//VoloMobileBase.LogDebug (" ----> is null");

			if (App.Current.IsExecutableStep (itemStemp)) {
				DetailStepPage.CellViewAccordionControl (this);
			}

			DetailStepPage.listView.SelectedItem = null;

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


		private void TappedCell(Step stepContext){

			//HERE IT'S SLOW
			Button button1 = new Button {
				Text = "Arrivo",
				Font = Font.SystemFontOfSize (NamedSize.Micro),
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = AppStyle.ColorButtonOrder,
				TextColor = Color.White,
				MinimumWidthRequest = 100,
				WidthRequest = 100,

			};

			button1.Clicked += OnButtonClicked;

			Button button2 = new Button {
				Text = "Stato",
				Font = Font.SystemFontOfSize (NamedSize.Micro),
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = AppStyle.ColorButtonOrder,
				TextColor = Color.White,
				MinimumWidthRequest = 100,
				WidthRequest = 100
			};
			Button button3 = new Button {
				Text = "Partenza",
				Font = Font.SystemFontOfSize (NamedSize.Micro),
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = AppStyle.ColorButtonOrder,
				TextColor = Color.White,
				MinimumWidthRequest = 100,
				WidthRequest = 100
			};

			var label3 = new Label {
				Text = ">",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				HorizontalTextAlignment = TextAlignment.End,
				VerticalTextAlignment = TextAlignment.Center,
				//LineBreakMode = LineBreakMode.TailTruncation
			};



			gridTap.Children.Add (button1, 0, 1, 0, 1);
			gridTap.Children.Add (button2, 1, 2, 0, 1);
			gridTap.Children.Add (button3, 2, 3, 0, 1);
			gridTap.Children.Add (VertLine (Color.FromHex ("fff"), gridTap.Height), 3, 4, 0, 1);
			gridTap.Children.Add (label3, 4, 5, 0, 1);


			// Columns 0,1,2  row 2
			grid.Children.Add (gridTap, 0, 4, 2, 3);
		}



		void OnButtonClicked(object sender, EventArgs e)
		{
			var itemStemp = (Step)BindingContext;

		}


	}
}

