using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;

namespace SampleApp
{
	public class MenuPage : ContentPage
	{
		MasterDetailPage master;
		TableView tableView;

		public MenuPage ()
		{
			Icon = "settings.png";
			Title = "Menu";



			var section = new TableSection () {
				new TextCell {Text = "Info",TextColor=Color.White},
				new TextCell {Text = "Exit",TextColor=Color.White},

			};


			var root = new TableRoot () {section} ;

			tableView = new TableView ()
			{ 
				Root = root,
				Intent = TableIntent.Menu,
				BackgroundColor =Color.FromHex("#132248"),

			};

			var logoutButton = new Button { Text = "Logout" };
			logoutButton.Clicked += (sender, e) => {
				//App.Current.Logout();
			};

			Content = new StackLayout {
				BackgroundColor = Color.FromHex("#132248"),

				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					tableView, 
					logoutButton
				}
			};
		}




	}
}