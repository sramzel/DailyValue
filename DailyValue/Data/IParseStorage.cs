﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoXaml
{
	public interface IParseStorage
	{
		Task<List<TodoItem>> RefreshDataAsync();

		Task<TodoItem> GetTodoItemAsync (string id);

		Task SaveTodoItemAsync (TodoItem item);

		Task DeleteTodoItemAsync (TodoItem id);
	}
}

