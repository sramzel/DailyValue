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
			var todoItem = (FoodWeights)BindingContext;
			await App.Fndds.FoodWeights.SaveItemAsync(todoItem);
			await this.Navigation.PopAsync();
		}

		async void OnDeleteActivated (object sender, EventArgs e)
		{
			var todoItem = (FoodWeights)BindingContext;
			await App.Fndds.FoodWeights.DeleteItemAsync(todoItem);
			await this.Navigation.PopAsync();
		}

		void OnCancelActivated (object sender, EventArgs e)
		{
			this.Navigation.PopAsync();
		}

		void OnSpeakActivated (object sender, EventArgs e)
		{
			var todoItem = (FoodWeights)BindingContext;
			App.Speech.Speak(todoItem.FoodCode + " " + todoItem.Score);
		}
	}
}

