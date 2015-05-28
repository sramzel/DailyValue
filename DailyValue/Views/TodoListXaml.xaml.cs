using System;
using Xamarin.Forms;

// http://forums.xamarin.com/discussion/11279/quickui-xaml-gets-started/

namespace DailyValue
{
	public partial class TodoListXaml : ContentPage
	{
		public TodoListXaml ()
		{
			InitializeComponent ();

			var tbi = new ToolbarItem ("+", null, () => {
				var todoItem = new FoodWeights();
				var todoPage = new TodoItemXaml();
				todoPage.BindingContext = todoItem;
				Navigation.PushAsync(todoPage);
			}, 0, 0);
			if (Device.OS == TargetPlatform.Android) { // BUG: Android doesn't support the icon being null
				tbi = new ToolbarItem ("+", "plus", () => {
					var todoItem = new FoodWeights();
					var todoPage = new TodoItemXaml();
					todoPage.BindingContext = todoItem;
					Navigation.PushAsync(todoPage);
				}, 0, 0);
			}

			ToolbarItems.Add (tbi);

//			if (Device.OS == TargetPlatform.iOS) {
//				var tbi2 = new ToolbarItem ("?", null, () => {
//					var todos = App.Database.GetItemsNotDone();
//					var tospeak = "";
//					foreach (var t in todos)
//						tospeak += t.Name + " ";
//					if (tospeak == "") tospeak = "there are no tasks to do";
//					App.Speech.Speak(tospeak);
//				}, 0, 0);
//				ToolbarItems.Add (tbi2);
//			}
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();
			listView.ItemsSource = await App.Fndds.FoodWeights.RefreshDataAsync ();
		}

		public void OnItemSelected (object sender, SelectedItemChangedEventArgs e) {
			var todoItem = e.SelectedItem as FoodWeights;
			var todoPage = new TodoItemXaml();
			todoPage.BindingContext = todoItem;
			Navigation.PushAsync(todoPage);
		}
	}
}