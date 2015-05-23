using System;
using Xamarin.Forms;

namespace DailyValue
{
	public static class App
	{
		#region Parse stuff
		static IParseStorage<TodoItem> parseStorage;

		public static IParseStorage<TodoItem> ParseStorage {
			get { return parseStorage; }
			set { parseStorage = value; }
		}

		public static void SetParseStorage (IParseStorage<TodoItem> todoItemManager)
		{
			ParseStorage = todoItemManager;
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

