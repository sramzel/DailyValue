using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Parse;

namespace DailyValue.iOS
{
	public class ParseStorageIOS<M> :IParseStorage<M>
	{
		public string ClassName{ get; private set;}

		public ParseStorageIOS(string className){
			ClassName = className;
		}

		public override async Task<List<M>> RefreshDataAsync()
		{
			var query = ParseObject.GetQuery (ClassName);
			var ie = await query.FindAsync ();

			var Items = new List<M> ();
			foreach (var t in ie) {
				Items.Add (From (new ParseObjectIOS(t)));
			}

			return Items;
		}

		public override async Task SaveItemAsync(M todoItem)
		{
			await Parse (todoItem).SaveAsync ();
		}

		public override async Task<M> GetItemAsync(string id)
		{
			var query = ParseObject.GetQuery(ClassName).WhereEqualTo(ClassName, id);
			var t = await query.FirstAsync();
			return From (new ParseObjectIOS(t));
		}

		public override async Task DeleteItemAsync(M item)
		{
			try 
			{
				await Parse(item).DeleteAsync();
			} 
			catch (Exception e) 
			{
				Console.Error.WriteLine(@"				ERROR {0}", e.Message);
			}
		}

		public override PclParseObject CreateObject(){
			return new ParseObjectIOS (ClassName);
		}
	}
}