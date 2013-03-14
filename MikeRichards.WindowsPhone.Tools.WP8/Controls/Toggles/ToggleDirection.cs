namespace MikeRichards.WindowsPhone.Tools.WP8.Controls.Toggles
{
	public enum ToggleDirection
	{
		Left,
		Right
	}

	public static class ToggleDirectionExtensions
	{
		public static ToggleDirection Opposite(this ToggleDirection toggleDirection)
		{
			return toggleDirection == ToggleDirection.Left ? ToggleDirection.Right : ToggleDirection.Left;
		}
	}
}
