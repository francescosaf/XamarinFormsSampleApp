using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace SampleApp
{
	public class DetailStepPageOk : ContentPage
	{
		public static ListView listView;
		StackLayout layout;
		private static List<StepCellAnimateHeightOk> m_entries = new List<StepCellAnimateHeightOk> ();
		//public static Image iconmap;
		public DetailStepPageOk ()
		{
			NavigationPage.SetHasNavigationBar(this,true);
			NavigationPage.SetHasBackButton(this, false);
			NavigationPage.SetTitleIcon(this, "workwavewleet_logo_horizontal_pma_rev.png");//ok per android
			Label header = new Label
			{
				Text = "Routes",
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			//iconmap= new Image { Aspect = Aspect.AspectFit };
			//iconmap.Source = ImageSource.FromFile ("icon_map.png");

			var model = new StepViewModel();
			BindingContext = model;
			listView = new ListView(ListViewCachingStrategy.RetainElement) {BackgroundColor = Color.White,SeparatorColor=Color.Black,SeparatorVisibility=SeparatorVisibility.Default};
			DataTemplate listTemplate = new DataTemplate(typeof(StepCellAnimateHeightOk));
			//listTemplate.SetValue (StepCellAnimateHeight.temp, listView);
			listView.ItemTemplate = listTemplate;
			listView.SetBinding (ListView.ItemsSourceProperty, "StepsObservable");
			listView.IsPullToRefreshEnabled = true;
			listView.HasUnevenRows = true;
			//listView.

			var grid = new Grid {
				Padding = new Thickness(0, Device.OnPlatform(5, 5, 5), 0, 5)	,
				RowSpacing=5,
				ColumnSpacing=0,
				BackgroundColor=Color.White
			};
			// Define columns
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Absolute) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Absolute) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
			grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Absolute) });
			Label label1 = new Label () { 
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center,
				TextColor=AppStyle.ColorBlue,
				HorizontalTextAlignment=TextAlignment.Center
			};

			label1.SetBinding (Label.TextProperty, "StepCountText");

			/*
			Label label2 = new Label () { Text = "Ordini",
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center,
				TextColor=Color.FromHex("132248"),BackgroundColor=Color.Blue, };
			*/
			Label label3 = new Label () { Text = "Oggi >",
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				TextColor=AppStyle.ColorBlue };

			Label label4 = new Label () { 
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				TextColor=AppStyle.ColorBlue ,
				HorizontalTextAlignment=TextAlignment.Center};
			label4.SetBinding (Label.TextProperty, "ViolazioniCountText");


			grid.Children.Add (new BoxOrdini(label1,50,50), 0, 1,0,2);
			//grid.Children.Add(label2, 0, 1, 1, 2);

			grid.Children.Add (VertLine (),1,2,0,2);

			grid.Children.Add(label3, 2, 3, 0, 2);

			grid.Children.Add (VertLine (),3,4,0,2);

			grid.Children.Add(label4, 4, 5, 0, 2);
			//grid.Children.Add(label5, 4,5, 1, 2);

			var shadowImage = new Image () {
				Source = "HeaderShadow.png",
				InputTransparent = true,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Aspect = Aspect.Fill
			};

			grid.Children.Add(shadowImage, 0, 5, 2, 3);


			layout = new StackLayout {Spacing=0};
			layout.Children.Add (grid);
			layout.Children.Add (listView);
			//this.Title = "xxxxx Route xxxx";

			listView.Refreshing += Lv_Refreshing;

			Content = layout;

		}

		private BoxView VertLine ()
		{
			return  new BoxView () {
				Color = Color.FromHex ("ddd"),
				WidthRequest = 1,
				MinimumWidthRequest = 10,
				MinimumHeightRequest = 10,
			};
		}


		public static void CellViewAccordionControl(StepCellAnimateHeightOk cellViewTapped){
			

			if (cellViewTapped._detailsRow.Height.Value == 0) {
				foreach (var child in m_entries.ToList())
				{  
					child._detailsRow.Height = 0;
					m_entries.Remove (child);
				}
				cellViewTapped._detailsRow.Height = cellViewTapped._detailsRowHeight;
				cellViewTapped.ForceUpdateSize ();
				m_entries.Add (cellViewTapped);

			} else {
				cellViewTapped._detailsRow.Height = 0;
				cellViewTapped.ForceUpdateSize ();
				m_entries.Remove (cellViewTapped);

			}
		}

		void Lv_Refreshing (object sender, EventArgs e)
		{
			//App.Current.voloMobile.RequestSyncNow();
			//App.Current.voloMobile.LogInfo("REFRESH.......");
			if ( listView.IsRefreshing )
			{
				listView.EndRefresh();
			}
		}





	}
}

