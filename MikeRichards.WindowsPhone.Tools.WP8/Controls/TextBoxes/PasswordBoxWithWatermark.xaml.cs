using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MikeRichards.WindowsPhone.Tools.WP8.Controls.TextBoxes
{
	public partial class PasswordBoxWithWatermark : UserControl
	{
		public PasswordBoxWithWatermark()
		{
			InitializeComponent();
		}

		[Description("Gets or Sets the password")]
		public string Password
		{
			get { return PasswordBox.Password; }
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					HidePasswordBox();
				}
				else
				{
					ShowPasswordBox();
				}

				PasswordBox.Password = value;
			}
		}

		[Description("Gets or Sets the watermark text")]
		public string Watermark
		{
			get { return (string)PasswordWatermarkBox.GetValue(TextBoxWithWatermark.WatermarkProperty); }
			set { PasswordWatermarkBox.SetValue(TextBoxWithWatermark.WatermarkProperty, value); }
		}

		[Description("Gets or Sets the watermark color")]
		public Brush WatermarkColor
		{
			get { return (Brush)PasswordWatermarkBox.GetValue(TextBoxWithWatermark.WatermarkColorProperty); }
			set { PasswordWatermarkBox.SetValue(TextBoxWithWatermark.WatermarkColorProperty, value); }
		}

		[Description("Gets or Sets the height")]
		public new double Height
		{
			get { return GetProperty<double>(HeightProperty); }
			set { SetProperty(HeightProperty, value, true); }
		}

		[Description("Gets or Sets the width")]
		public new double Width
		{
			get { return GetProperty<double>(WidthProperty); }
			set { SetProperty(WidthProperty, value, true); }
		}

		[Description("Gets or Sets the text wrapping")]
		public TextWrapping TextWrapping
		{
			get { return (TextWrapping)PasswordWatermarkBox.GetValue(TextBox.TextWrappingProperty); }
			set { PasswordWatermarkBox.SetValue(TextBox.TextWrappingProperty, value); }
		}

		[Description("Gets or Sets the border color")]
		public new Brush BorderBrush
		{
			get { return GetProperty<Brush>(BorderBrushProperty); }
			set { SetProperty(BorderBrushProperty, value); }
		}

		[Description("Gets or Sets the thickness")]
		public new Thickness BorderThickness
		{
			get { return GetProperty<Thickness>(BorderThicknessProperty); }
			set { SetProperty(BorderThicknessProperty, value); }
		}

		[Description("Gets or Sets the text alignment")]
		public TextAlignment TextAlignment
		{
			get { return (TextAlignment)PasswordWatermarkBox.GetValue(TextBox.TextAlignmentProperty); }
			set { PasswordWatermarkBox.SetValue(TextBox.TextAlignmentProperty, value); }
		}

		[Description("Gets or Sets the font size")]
		public new double FontSize
		{
			get { return GetProperty<double>(FontSizeProperty); }
			set { SetProperty(FontSizeProperty, value); }
		}

		[Description("Gets or Set the background")]
		public new Brush Background
		{
			get { return GetProperty<Brush>(BackgroundProperty); }
			set { SetProperty(BackgroundProperty, value); }
		}

		[Description("Gets or Set the background")]
		public Brush SelectionBackground { get; set; }

		private Brush OriginalBackground { get; set; }

		public new void Focus()
		{
			HidePasswordBox();
			PasswordBox.Focus();
		}

		private void PasswordWatermarkBox_OnGotFocus(object sender, RoutedEventArgs e)
		{
			ShowPasswordBox(true);
		}

		private void PasswordWatermarkBox_OnLostFocus(object sender, RoutedEventArgs e)
		{
			OriginalBackground = Background;
			Background = SelectionBackground;
			PasswordBox.Background = SelectionBackground;
		}

		private void PasswordBox_OnGotFocus(object sender, RoutedEventArgs e)
		{
			OriginalBackground = Background;
			Background = SelectionBackground;
			((PasswordBox)sender).Background = SelectionBackground;
		}

		private void PasswordBox_OnLostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(Password))
			{
				HidePasswordBox();
			}

			Background = OriginalBackground;
		}

		private void ShowPasswordBox(bool doFocus = false)
		{
			PasswordWatermarkBox.Visibility = Visibility.Collapsed;
			PasswordBox.Visibility = Visibility.Visible;

			if (doFocus) PasswordBox.Focus();
		}

		private void HidePasswordBox()
		{
			PasswordBox.Visibility = Visibility.Collapsed;
			PasswordWatermarkBox.Visibility = Visibility.Visible;
		}

		private T GetProperty<T>(DependencyProperty dp)
		{
			return (T)PasswordBox.GetValue(dp);
		}

		private void SetProperty(DependencyProperty dp, object value, bool includeSelf = false)
		{
			if (includeSelf) SetValue(dp, value);
			PasswordBox.SetValue(dp, value);
			PasswordWatermarkBox.SetValue(dp, value);
		}
	}
}
