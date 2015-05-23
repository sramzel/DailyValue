using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace TodoXaml
{
	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public class TodoItemManager<P> {

		IParseStorage<TodoItem, P> storage;

		public TodoItemManager (IParseStorage<TodoItem, P> storage) 
		{
			this.storage = storage;
		}

		public Task<TodoItem> GetTaskAsync(string id)
		{
			return storage.GetItemAsync(id);
		}

		public Task<List<TodoItem>> GetTasksAsync ()
		{
			return storage.RefreshDataAsync();
		}

		public Task SaveTaskAsync (TodoItem item)
		{
			return storage.SaveItemAsync(item);
		}

		public Task DeleteTaskAsync (TodoItem item)
		{
			return storage.DeleteItemAsync(item);
		}
	}
}

