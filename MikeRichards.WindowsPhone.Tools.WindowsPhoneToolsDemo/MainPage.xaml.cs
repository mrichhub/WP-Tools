using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace MikeRichards.WindowsPhone.Tools.WindowsPhoneToolsDemo
{
	public partial class MainPage : PhoneApplicationPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void TextBoxesButton_OnClick(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/TextBoxes.xaml", UriKind.Relative));
		}

		private void TogglesButton_OnClick(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/Toggles.xaml", UriKind.Relative));
		}
	}
}