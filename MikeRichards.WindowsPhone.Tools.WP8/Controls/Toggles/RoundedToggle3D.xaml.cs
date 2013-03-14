﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MikeRichards.WindowsPhone.Tools.WP8.Controls.Toggles
{
	public partial class RoundedToggle3D : Toggle
	{
		public RoundedToggle3D()
		{
			InitializeComponent();
		}

		protected override UIElement ToggleSwitchElement
		{
			get { return SwitchEllipse; }
		}

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

		[Description("Gets or Sets the Foreground Brush of the content labels")]
		public Brush ContentForeground
		{
			get { return ContentLeftTextBlock.Foreground; }
			set { ContentLeftTextBlock.Foreground = ContentRightTextBlock.Foreground = value; }
		}


		private void Toggle_OnTap(object sender, GestureEventArgs e)
		{
			ToggleSwitch();
		}

		private void ToggleLeft_OnTap(object sender, GestureEventArgs e)
		{
			ToggleLeft();
		}

		private void ToggleRight_OnTap(object sender, GestureEventArgs e)
		{
			ToggleRight();
		}
	}
}
