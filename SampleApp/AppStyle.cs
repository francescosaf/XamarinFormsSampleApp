using System;

using System;
using Xamarin.Forms;

namespace SampleApp
{
	public static class AppStyle
	{
		public static Color ColorBlue = Color.FromHex("#132248");
		public static Color ColorGreen = Color.FromHex("#FF639F21");
		public static Color ColorButtonOrder = Color.FromHex("#FF31456A");
		public static Color ColorButtonOrderPressed = Color.FromHex("#FF19305A");
		public static Color ColorMyGray = Color.FromHex("#FFE0E0E0");
		public static Color ColorTextList = Color.FromHex("#000");

		public static Color Blueworkwavebackground=Color.FromHex("#FF8CC82D"); //verde 
		public static Color edittextbackground=Color.FromHex("#FFAED76F"); //verde chiaor
		public static Color buttonloginpressed=Color.FromHex("#FFA4D165"); //verde chiaro
		public static Color buttonlogindisabled=Color.FromHex("#FF7FB134"); //verde
		public static Color buttonloginenabled=Color.FromHex("#FF719F2E"); //verder scuro
		public static Color workwavebackgroundbar=Color.FromHex("#ff19305a"); //blu
		public static Color buttonorderpressed=Color.FromHex("#FF374F75"); //blu chiaro
		public static Color buttonorderdisabled=Color.FromHex("#FF31456A"); //blu scuro
		public static Color buttonorderenabled=Color.FromHex("#FF31456A"); //blu scuro
		public static Color headertext=Color.FromHex("#FF19305a"); //blu
		public static Color workwave_green=Color.FromHex("#FF639f21");
		public static Color workwave_red=Color.FromHex("#FFaf4425");
		public static Color workwave_green_line=Color.FromHex("#FF83B34F");
		public static Color workwave_executed_order=Color.FromHex("#FFC0C0C0");
		public static Color workwave_executed_order_line=Color.FromHex("#FFEBEBEB");
		public static Color workwave_depot_line=Color.FromHex("#FF4F5EBC");
		public static Color workwave_blue=Color.FromHex("#FF19305A");
		public static Color workwave_yellow=Color.FromHex("#FFc4bb2c");
		public static Color mygray=Color.FromHex("#ffe0e0e0");

		public static Button button1 = new Button {
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
	}
}