using System;
using Xamarin.Forms;

namespace TodoXaml
{
	public static class App
	{
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

