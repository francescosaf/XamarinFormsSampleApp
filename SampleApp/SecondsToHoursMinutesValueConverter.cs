using System;
using Xamarin.Forms;
using System.Globalization;

namespace SampleApp
{
	public class SecondsToHoursMinutesValueConverter 
		: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var t = TimeSpan.FromSeconds((int)value);

			return string.Format("{0:D2}:{1:D2}", t.Hours, t.Minutes);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

