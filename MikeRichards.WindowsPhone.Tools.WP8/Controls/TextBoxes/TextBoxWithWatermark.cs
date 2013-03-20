using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MikeRichards.WindowsPhone.Tools.WP8.Controls.TextBoxes
{
	public partial class TextBoxWithWatermark : TextBox
	{
		private bool _isInit;

		[Description("Gets or Sets the watermark value")]
		public string Watermark { get; set; }

		[Description("Gets or Sets the watermark color brush")]
		public Brush WatermarkColor { get; set; }

		private Brush OriginalForeground { get; set; }

		protected override void OnGotFocus(RoutedEventArgs e)
		{
			if (string.Equals(Text, Watermark, StringComparison.CurrentCultureIgnoreCase))
			{
				Text = "";
				Foreground = OriginalForeground;
			}

			base.OnGotFocus(e);
		}

		protected override void OnLostFocus(RoutedEventArgs e)
		{
			if (string.Equals(Text, string.Empty, StringComparison.CurrentCultureIgnoreCase))
			{
				Foreground = WatermarkColor ?? Foreground;
				Text = Watermark;
			}

			base.OnLostFocus(e);
		}

		public override void OnApplyTemplate()
		{
			if (!_isInit)
			{
				OriginalForeground = Foreground;

				Text = Watermark;
				Foreground = WatermarkColor ?? Foreground;

				_isInit = true;
			}

			base.OnApplyTemplate();
		}
	}
}
