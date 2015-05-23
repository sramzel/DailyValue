using System;
using System.Threading.Tasks;

namespace DailyValue
{
	public class TodoParseAdapter : IParseAdapter<TodoItem>
	{
		private const string CLASS = "Task";
		private const string FIELD_ID = "objectId";
		private const string FIELD_TITLE = "Title";
		private const string FIELD_IS_DONE = "IsDone";
		private const string FIELD_DESCRIPTION = "Description";

		public string ClassName {
			get { return CLASS; }
		}

		public string IdField {
			get { return FIELD_ID; }
		}
		public TodoItem From (IParseObject po){
			var t = new TodoItem();
			t.ID = po.ObjectId;
			t.Name = Convert.ToString(po[FIELD_TITLE]);
			t.Notes = Convert.ToString (po [FIELD_DESCRIPTION]);
			t.Done = Convert.ToBoolean (po [FIELD_IS_DONE]);
			return t;
		}

		public IParseObject Parse (TodoItem todo){
			var po = App.ParseStorage.CreateObject(CLASS);
			if (todo.ID != string.Empty)
				po.ObjectId = todo.ID;
			po[FIELD_TITLE] = todo.Name;
			po[FIELD_DESCRIPTION] = todo.Notes;
			po[FIELD_IS_DONE] = todo.Done;

			return po;
		}
	}
}

