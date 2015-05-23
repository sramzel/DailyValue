using System;
using Parse;
using System.Threading.Tasks;

namespace DailyValue.iOS
{
	public class TodoParseAdapter : IParseAdapter<TodoItem>
	{
		public string GetClassName () {
			return "Task";
		}

		public string GetIdField () {
			return "objectId";
		}

		public string GetSortField () {
			return"title";
		}

		public TodoItem From (Object o){
			var po = o as ParseObject;
			var t = new TodoItem();
			t.ID = po.ObjectId;
			t.Name = Convert.ToString(po["Title"]);
			t.Notes = Convert.ToString (po["Description"]);
			t.Done = Convert.ToBoolean (po["IsDone"]);
			return t;
		}

		public Object Parse (TodoItem todo){
			var po = new ParseObject("Task");
			if (todo.ID != string.Empty)
				po.ObjectId = todo.ID;
			po["Title"] = todo.Name;
			po["Description"] = todo.Notes;
			po["IsDone"] = todo.Done;

			return po;
		}
	}
}

