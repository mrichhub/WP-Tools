using System.Windows;
using System.Windows.Input;

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
