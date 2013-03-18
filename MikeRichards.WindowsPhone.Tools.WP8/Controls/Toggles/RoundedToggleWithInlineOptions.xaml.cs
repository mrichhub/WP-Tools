using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MikeRichards.WindowsPhone.Tools.WP8.Controls.Toggles
{
	public partial class RoundedToggleWithInlineOptions : Toggle
	{
		public RoundedToggleWithInlineOptions()
		{
			InitializeComponent();
		}

		protected override UIElement ToggleSwitchElement { get { return ToggleSwitch; } }
		protected override double ToggleLeftMostState { get { return -78.0; } }
		protected override double ToggleRightMostState { get { return 2.0; } }


		[Description("Gets or Sets the content label to the left of the switch")]
		public string ContentLeft
		{
			get { return ContentLeftTextBlock.GetValue(TextBlock.TextProperty) as string; }
			set { ContentLeftTextBlock.SetValue(TextBlock.TextProperty, value); }
		}

		[Description("Gets or Sets the content label to the right of the switch")]
		public string ContentRight
		{
			get { return ContentRightTextBlock.GetValue(TextBlock.TextProperty) as string; }
			set { ContentRightTextBlock.SetValue(TextBlock.TextProperty, value); }
		}

		[Description("Gets or Sets the fill brush for the switch")]
		public Brush Fill
		{
			get { return SwitchContainer.Fill; }
			set { SwitchContainer.Fill = value; }
		}

		[Description("Gets or Sets the foreground brush of all the toggle elements")]
		public new Brush Foreground
		{
			get { return ToggleCircle.Fill; }
			set { ToggleCircle.Fill = ToggleCircle.Stroke = ContentRightTextBlock.Foreground = ContentLeftTextBlock.Foreground = value; }
		}

		[Description("Gets or Sets the border brush")]
		public Brush Border
		{
			get { return SwitchContainer.Stroke; }
			set { SwitchContainer.Stroke = value; }
		}

		private void Toggle_OnTap(object sender, GestureEventArgs e)
		{
			ToggleSwitch();
		}
	}
}
