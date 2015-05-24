using System;
using Xamarin.Forms;

namespace DailyValue
{
	public partial class TodoItemXaml : ContentPage
	{
		public TodoItemXaml ()
		{
			InitializeComponent ();	
		}

		async void OnSaveActivated (object sender, EventArgs e)
		{
			var todoItem = (MainFoodDesc)BindingContext;
			await App.Fndds.MainFoodDesc.SaveItemAsync(todoItem);
			await this.Navigation.PopAsync();
		}

		async void OnDeleteActivated (object sender, EventArgs e)
		{
			var todoItem = (MainFoodDesc)BindingContext;
			await App.Fndds.MainFoodDesc.DeleteItemAsync(todoItem);
			await this.Navigation.PopAsync();
		}

		void OnCancelActivated (object sender, EventArgs e)
		{
			this.Navigation.PopAsync();
		}

		void OnSpeakActivated (object sender, EventArgs e)
		{
			var todoItem = (MainFoodDesc)BindingContext;
			App.Speech.Speak(todoItem.AbbreviatedDescription + " " + todoItem.MainFoodDescription);
		}
	}
}

