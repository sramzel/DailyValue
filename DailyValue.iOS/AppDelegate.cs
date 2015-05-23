using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;
using Parse;

namespace DailyValue.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		ParseStorageIOS<TodoItem> parseStorage;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			#region Parse stuff
			ParseClient.Initialize (Constants.ApplicationId, Constants.Key);
			parseStorage = new ParseStorageIOS<TodoItem>(new TodoParseAdapter());

			App.SetParseStorage (parseStorage);

			#endregion

			#region Text to Speech stuff
			App.SetTextToSpeech (new Speech ());
			#endregion region

			// If you have defined a view, add it here:
			// window.RootViewController  = navigationController;
			window.RootViewController = App.GetMainPage ().CreateViewController ();

			// make the window visible
			window.MakeKeyAndVisible ();

			return true;
		}
	}
}