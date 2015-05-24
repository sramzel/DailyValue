using System;
using Xamarin.Forms;

namespace DailyValue
{
	public static class App
	{
		#region Parse stuff
		static FnddsDatabase parseDatabase;

		public static FnddsDatabase Fndds {
			get { return parseDatabase; }
			set { parseDatabase = value; }
		}
		#endregion

		public static Page GetMainPage ()
		{
			var tdlx = new TodoListXaml ();
			var mainNav = new NavigationPage (tdlx);

			return mainNav;
		}

		#region Text to Speech stuff
		static ITextToSpeech TextToSpeech;
		public static void SetTextToSpeech (ITextToSpeech speech)
		{
			TextToSpeech = speech;
		}
		public static ITextToSpeech Speech {
			get { return TextToSpeech; }
		}
		#endregion
	}
}

