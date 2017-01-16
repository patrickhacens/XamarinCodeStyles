# XamarinCodeStyles

A .net lib to help you make styles in xamarin without all the hassle to use xaml

## Installation

> Install-Package Patrickhacens.CodeStyles

or download from [nuget](https://www.nuget.org/packages/Patrickhacens.CodeStyles/)

## Usage
In your App's construtor you just need to call `this.SetCodeStyles`
```
using CodeStyles;
...
public class App : Application
{
	public App()
	{
		this.SetCodeStyles(); //load all styles into your app
		//continue with the normal flux of your app
		MainPage = new LoginPage();
	}
}
```
and in any class you like create your styles and annotate them with the `StyleAttribute`, both class and method
```
[Style]
public static class ButtonStyles
{
	[Style]
	static Style GetFacebookButton()
	{
		return new Style(typeof(Button))
		{
			Class = "facebook",
			ApplyToDerivedTypes = true,
			Setters =
			{
				{ Button.ImageProperty, "fbicon" },
				{ Button.BackgroundColorProperty, Color.FromHex("3B5998") },
				{ Button.TextColorProperty, Color.White }
			}
		};
	}
	
	[Style]
	static Style GetGoogleButton()
	{
		return new Style(typeof(Button))
		{
			Class = "google",
			ApplyToDerivedTypes = true,
			Setters =
			{
				{ Button.ImageProperty, "gplusicon" },
				{ Button.BackgroundColorProperty, Color.FromHex("D95032") },
				{ Button.TextColorProperty, Color.White }
			}
		};
	}
}
```

it works both with methods that returns one style like above or methods that return a collection of styles just remember to make your methods <b>static</b>
