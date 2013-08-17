using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MikeRichards.WindowsPhone.Tools.WP8.Controls.TextBoxes
{
	public partial class TextBoxWithWatermark : TextBox
	{
		[Description("Gets or Sets the watermark text")]
		public string Watermark
		{
			get { return (string)GetValue(WatermarkProperty); }
			set { SetValue(WatermarkProperty, value); }
		}

		public static readonly DependencyProperty WatermarkProperty =
			DependencyProperty.Register("Watermark", typeof(string), typeof(TextBoxWithWatermark), new PropertyMetadata(default(string), OnWatermarkPropertyChanged));

		private static void OnWatermarkPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (!(d is TextBoxWithWatermark)) return;

			var textBoxWithWaterMark = (TextBoxWithWatermark)d;
			if (string.IsNullOrEmpty(textBoxWithWaterMark.Text) || string.Equals(e.OldValue, textBoxWithWaterMark.Text))
			{
				textBoxWithWaterMark.ShowWatermark();
			}
		}

		[Description("Gets or Sets the watermark color")]
		public Brush WatermarkColor
		{
			get { return (Brush)GetValue(WatermarkColorProperty); }
			set
			{
				SetValue(WatermarkColorProperty, value);
				ShowWatermarkIfTextBoxEmpty();
			}
		}

		public static readonly DependencyProperty WatermarkColorProperty =
			DependencyProperty.Register("WatermarkColor", typeof(Brush), typeof(TextBoxWithWatermark),
										new PropertyMetadata(default(Brush)));

		private Brush OriginalForeground { get; set; }
		private Brush OriginalBackground { get; set; }

		public new string Text
		{
			get
			{
				string textValue = base.Text;

				if (string.Equals(textValue, Watermark, StringComparison.CurrentCulture))
				{
					textValue = string.Empty;
				}

				return textValue;
			}
			set { base.Text = value; }
		}


		protected override void OnGotFocus(RoutedEventArgs e)
		{
			HideWatermark();

			base.OnGotFocus(e);

			OriginalBackground = Background;
			Background = SelectionBackground;
		}

		protected override void OnLostFocus(RoutedEventArgs e)
		{
			ShowWatermarkIfTextBoxEmpty();

			base.OnLostFocus(e);

			Background = OriginalBackground;
		}

		public override void OnApplyTemplate()
		{
			ShowWatermarkIfTextBoxEmpty();

			if (!string.IsNullOrEmpty(Text))
			{
				HideWatermark();
			}

			base.OnApplyTemplate();
		}

		private void ShowWatermarkIfTextBoxEmpty()
		{
			if (string.IsNullOrEmpty(Text))
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

		private void HideWatermark()
		{
			if (string.Equals(base.Text, Watermark, StringComparison.CurrentCultureIgnoreCase)) Text = "";
			Foreground = OriginalForeground ?? Foreground;
		}
	}
}
