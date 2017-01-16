using Xamarin.Forms;

namespace CodeStyles.Samples
{
	[Style]
	public class ButtonStyles
	{
		[Style]
		public static Style GetFacebookButton()
		{
			return new Style(typeof(Button))
			{
				Class = "facebook-purple",
				ApplyToDerivedTypes = true,
				Setters =
				{
					{ Button.BackgroundColorProperty, Color.FromHex("3B5998") },
					{ Button.TextColorProperty, Color.White }
				}
			};
		}
		[Style]
		public static Style GetGoogleButton()
		{
			return new Style(typeof(Button))
			{
				Class = "google-red",
				ApplyToDerivedTypes = true,
				Setters =
				{
					{ Button.BackgroundColorProperty, Color.FromHex("D95032") },
					{ Button.TextColorProperty, Color.White }
				}
			};
		}
	}
}
