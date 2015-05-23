using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Parse;

namespace DailyValue.iOS
{
	public class ParseStorageIOS<M> :IParseStorage<M>
	{
		public List<M> Items { get; private set;}

		// Constructor
		public ParseStorageIOS(IParseAdapter<M> parseFactory) : base(parseFactory)
		{
			Items = new List<M>();

			ParseClient.Initialize (Constants.ApplicationId, Constants.Key);
		}

		async public override Task<List<M>> RefreshDataAsync()
		{
			var query = ParseObject.GetQuery (ParseFactory.ClassName);
			var ie = await query.FindAsync ();

			var Items = new List<M> ();
			foreach (var t in ie) {
				Items.Add (ParseFactory.From (new ParseObjectIOS(t)));
			}

			return Items;
		}

		public override async Task SaveItemAsync(M todoItem)
		{
			await ParseFactory.Parse (todoItem).SaveAsync ();
		}

		public override async Task<M> GetItemAsync(string id)
		{
			var query = ParseObject.GetQuery(ParseFactory.ClassName).WhereEqualTo(ParseFactory.IdField, id);
			var t = await query.FirstAsync();
			return ParseFactory.From (new ParseObjectIOS(t));
		}

		public override async Task DeleteItemAsync(M item)
		{
			try 
			{
				await ((ParseObject) ParseFactory.Parse(item)).DeleteAsync();
			} 
			catch (Exception e) 
			{
				Console.Error.WriteLine(@"				ERROR {0}", e.Message);
			}
		}

		public override IParseObject CreateObject(string className){
			return new ParseObjectIOS (className);
		}
	}
}