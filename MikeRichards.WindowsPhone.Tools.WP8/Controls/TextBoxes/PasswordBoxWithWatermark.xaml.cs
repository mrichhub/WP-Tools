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
			get { return (string)GetValue(WatermarkProperty); }
			set { SetValue(WatermarkProperty, value); }
		}

		public static readonly DependencyProperty WatermarkProperty =
			DependencyProperty.Register("Watermark", typeof (string), typeof (PasswordBoxWithWatermark),
				new PropertyMetadata(default(string),
					(o, args) =>
						((PasswordBoxWithWatermark) o).WatermarkTextBox.SetValue(TextBoxWithWatermark.WatermarkProperty, args.NewValue)));


		[Description("Gets or Sets the watermark color")]
		public Brush WatermarkColor
		{
			get { return (Brush)GetValue(WatermarkColorProperty); }
			set { SetValue(WatermarkColorProperty, value); }
		}

		public static readonly DependencyProperty WatermarkColorProperty =
			DependencyProperty.Register("WatermarkColor", typeof(Brush), typeof(PasswordBoxWithWatermark),
				new PropertyMetadata(default(Brush),
					(o, args) =>
						((PasswordBoxWithWatermark)o).WatermarkTextBox.SetValue(TextBoxWithWatermark.WatermarkColorProperty, args.NewValue)));

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
			get { return (TextWrapping)WatermarkTextBox.GetValue(TextBox.TextWrappingProperty); }
			set { WatermarkTextBox.SetValue(TextBox.TextWrappingProperty, value); }
		}

		[Description("Gets or Sets the border color")]
		public new Brush BorderBrush
		{
			get { return GetProperty<Brush>(BorderBrushProperty); }
			set { SetProperty(BorderBrushProperty, value); }
		}

		public new static readonly DependencyProperty BorderBrushProperty =
			DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(PasswordBoxWithWatermark),
				new PropertyMetadata(default(Brush),
					(o, args) =>
						((PasswordBoxWithWatermark)o).SetProperty(Control.BorderBrushProperty, args.NewValue)));

		[Description("Gets or Sets the thickness")]
		public new Thickness BorderThickness
		{
			get { return GetProperty<Thickness>(BorderThicknessProperty); }
			set { SetProperty(BorderThicknessProperty, value); }
		}

		public new static readonly DependencyProperty BorderThicknessProperty =
			DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(PasswordBoxWithWatermark),
				new PropertyMetadata(default(Thickness),
					(o, args) =>
						((PasswordBoxWithWatermark)o).SetProperty(Control.BorderThicknessProperty, args.NewValue)));

		[Description("Gets or Sets the text alignment")]
		public TextAlignment TextAlignment
		{
			get { return (TextAlignment)GetValue(TextAlignmentProperty); }
			set
			{
				SetValue(TextAlignmentProperty, value); 
				WatermarkTextBox.SetValue(TextBox.TextAlignmentProperty, value);
			}
		}

		public static readonly DependencyProperty TextAlignmentProperty =
			DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(PasswordBoxWithWatermark),
				new PropertyMetadata(TextAlignment.Left,
					(o, args) =>
						((PasswordBoxWithWatermark)o).WatermarkTextBox.SetValue(TextBox.TextAlignmentProperty, args.NewValue)));

		[Description("Gets or Sets the font size")]
		public new double FontSize
		{
			get { return GetProperty<double>(FontSizeProperty); }
			set { SetProperty(FontSizeProperty, value); }
		}

		[Description("Gets or Set the background")]
		public new Brush Background
		{
			get { return GetProperty<Brush>(Control.BackgroundProperty); }
			set { SetProperty(Control.BackgroundProperty, value); }
		}

		public new static readonly DependencyProperty BackgroundProperty =
			DependencyProperty.Register("Background", typeof(Brush), typeof(PasswordBoxWithWatermark),
				new PropertyMetadata(default(Brush),
					(o, args) =>
						((PasswordBoxWithWatermark)o).Background = (Brush)args.NewValue));

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
			//OriginalBackground = Background;
			//Background = SelectionBackground;
			//PasswordBox.Background = SelectionBackground;
		}

		private void PasswordBox_OnGotFocus(object sender, RoutedEventArgs e)
		{
			OriginalBackground = OriginalBackground ?? Background;
			Background = SelectionBackground ?? Background;
		}

		private void PasswordBox_OnLostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(Password))
			{
				HidePasswordBox();
			}

			if (OriginalBackground != null)
			{
				Background = OriginalBackground;
			}
		}

		private void ShowPasswordBox(bool doFocus = false)
		{
			WatermarkTextBox.Visibility = Visibility.Collapsed;
			PasswordBox.Visibility = Visibility.Visible;

			if (doFocus) PasswordBox.Focus();
		}

		private void HidePasswordBox()
		{
			PasswordBox.Visibility = Visibility.Collapsed;
			WatermarkTextBox.Visibility = Visibility.Visible;
		}

		private T GetProperty<T>(DependencyProperty dp)
		{
			return (T)PasswordBox.GetValue(dp);
		}

		private void SetProperty(DependencyProperty dp, object value, bool includeSelf = false)
		{
			if (includeSelf) SetValue(dp, value);
			PasswordBox.SetValue(dp, value);
			WatermarkTextBox.SetValue(dp, value);
		}
	}
}
