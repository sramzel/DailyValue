using System;
using TodoXaml;
using Parse;

namespace DailyValue.iOS
{
	public class TodoItemConvertFactory : IConvertFactory<TodoItem, ParseObject>
	{
		public TodoItemConvertFactory ()
		{
		}

		public TodoItem Convert(ParseObject parseObject){
			return null;
		}

		public ParseObject Convert(TodoItem todoItem){
			return null;
		}
	}
}

