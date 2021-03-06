﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MikeRichards.WindowsPhone.Tools.WP8.Controls.Toggles
{
	public partial class RoundedToggle : Toggle
	{
		public RoundedToggle()
		{
			InitializeComponent();
		}

		protected override UIElement ToggleSwitchElement { get { return SwitchEllipse; } }
		protected override double ToggleLeftMostState { get { return 2.0; } }
		protected override double ToggleRightMostState { get { return 42.0; } }


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

		private void Toggle_OnTap(object sender, GestureEventArgs e)
		{
			if (!e.Handled)
			{
				ToggleSwitch();
				e.Handled = true;
			}
		}

		private void ToggleLeft_OnTap(object sender, GestureEventArgs e)
		{
			if (!e.Handled)
			{
				ToggleLeft();
				e.Handled = true;
			}
		}

		private void ToggleRight_OnTap(object sender, GestureEventArgs e)
		{
			if (!e.Handled)
			{
				ToggleRight();
				e.Handled = true;
			}
		}
	}
}
