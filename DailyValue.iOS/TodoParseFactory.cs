using System;
using TodoXaml;
using Parse;

namespace DailyValue.iOS
{
	public class TodoParseFactory : IConvertFactory<TodoItem, ParseObject>
	{
		public TodoParseFactory ()
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

