using System;
using Xamarin.Forms;

namespace SampleApp
{
	public class MainPage : MasterDetailPage
	{
		public MainPage ()
		{

			var menuPage = new MenuPage ();
			Master = menuPage;
			NavigationPage navigationPage = new NavigationPage(new DetailStepPageOLD());
			navigationPage.BarBackgroundColor = AppStyle.workwavebackgroundbar;
			Detail = navigationPage;

		}

	}
}


