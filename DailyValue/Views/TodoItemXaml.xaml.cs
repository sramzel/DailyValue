﻿using System;
using Xamarin.Forms;

namespace TodoXaml
{
	public partial class TodoItemXaml : ContentPage
	{
		public TodoItemXaml ()
		{
			InitializeComponent ();	
		}

		async void OnSaveActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.SaveTaskAsync(todoItem);
			await this.Navigation.PopAsync();
		}

		async void OnDeleteActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.DeleteTaskAsync(todoItem);
			await this.Navigation.PopAsync();
		}

		void OnCancelActivated (object sender, EventArgs e)
		{
			this.Navigation.PopAsync();
		}

		void OnSpeakActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			App.Speech.Speak(todoItem.Name + " " + todoItem.Notes);
		}
	}
}

