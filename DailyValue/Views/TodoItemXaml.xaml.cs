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

		void OnCancelActivated (object sender, EventArgs e)
		{
			this.Navigation.PopAsync();
		}
	}
}

