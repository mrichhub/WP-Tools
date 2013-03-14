using MikeRichards.WindowsPhone.Tools.WindowsPhoneToolsDemo.Resources;

namespace MikeRichards.WindowsPhone.Tools.WindowsPhoneToolsDemo
{
	/// <summary>
	/// Provides access to string resources.
	/// </summary>
	public class LocalizedStrings
	{
		private static AppResources _localizedResources = new AppResources();

		public AppResources LocalizedResources { get { return _localizedResources; } }
	}
}