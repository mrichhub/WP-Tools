using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MikeRichards.WindowsPhone.Tools.WP8.Controls.TextBoxes
{
	public partial class TextBoxWithWatermark : TextBox
	{
		[Description("Gets or Sets the watermark value")]
		public string Watermark
		{
			get { return (string) GetValue(WatermarkProperty); }
			set { SetValue(WatermarkProperty, value); }
		}

		public static readonly DependencyProperty WatermarkProperty =
			DependencyProperty.Register("Watermark", typeof(string), typeof(TextBoxWithWatermark), new PropertyMetadata(default(string), OnWatermarkPropertyChanged));

		private static void OnWatermarkPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (!(d is TextBoxWithWatermark)) return;

			var textBoxWithWaterMark = (TextBoxWithWatermark) d;
			if (textBoxWithWaterMark.Text == string.Empty || string.Equals(textBoxWithWaterMark.Text, (string)e.OldValue, StringComparison.CurrentCultureIgnoreCase))
			{
				textBoxWithWaterMark.ShowWatermark();
			}
		}

		private Brush _watermarkColor;
		[Description("Gets or Sets the watermark color brush")]
		public Brush WatermarkColor
		{
			get { return _watermarkColor; }
			set 
			{ 
				_watermarkColor = value;
				ShowWatermarkIfTextBoxEmpty();
			}
		}

		private Brush OriginalForeground { get; set; }

		protected override void OnGotFocus(RoutedEventArgs e)
		{
			if (string.Equals(Text, Watermark, StringComparison.CurrentCultureIgnoreCase))
			{
				HideWatermark();
			}

			base.OnGotFocus(e);
		}

		protected override void OnLostFocus(RoutedEventArgs e)
		{
			ShowWatermarkIfTextBoxEmpty();
			base.OnLostFocus(e);
		}

		private void ShowWatermarkIfTextBoxEmpty()
		{
			if (string.Equals(Text, string.Empty, StringComparison.CurrentCultureIgnoreCase) || string.Equals(Text, Watermark, StringComparison.CurrentCultureIgnoreCase))
			{
				ShowWatermark();
			}
		}

		private void ShowWatermark()
		{
			OriginalForeground = OriginalForeground ?? Foreground;
			Foreground = WatermarkColor ?? Foreground;
			Text = Watermark ?? string.Empty;
		}

		public void HideWatermark()
		{
			Text = "";
			Foreground = OriginalForeground ?? Foreground;			
		}
	}
}
