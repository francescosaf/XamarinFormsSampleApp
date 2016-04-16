using System;
using Xamarin.Forms;

namespace SampleApp
{
	public class BoxOrdini: ContentView
	{
		public double BoxWidth  { get; set;}
		public double BoxHeight  { get; set;}
		public BoxOrdini (View content, double boxHeight, double boxWidth)
		{
			BoxWidth = boxWidth;
			BoxHeight = boxHeight;

			var frameImage = new Frame {
				Padding = 5,
				Content = content,
				BackgroundColor = Color.Gray.MultiplyAlpha(.5),
				HasShadow = false,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				OutlineColor = Color.Black,
				HeightRequest = BoxHeight,
				WidthRequest = BoxWidth,
				MinimumHeightRequest = BoxHeight,
				MinimumWidthRequest = BoxWidth,
			};

			var relativeLayout = new StackLayout();

			relativeLayout.Children.Add (frameImage);

			Content = relativeLayout;
		}
	}
}

