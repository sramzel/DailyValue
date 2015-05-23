using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Parse;

namespace TodoXaml.iOS
{
	public class TodoParseStorage :IParseStorage<TodoItem, ParseObject>
	{
		public List<TodoItem> Items { get; private set;}

		// Constructor
		TodoParseStorage(IConvertFactory<TodoItem, ParseObject> parseFactory) : base(parseFactory)
		{
			Items = new List<TodoItem>();

			// https://parse.com/apps/YOUR_APP_NAME/edit#app_keys
			// ApplicationId, Windows/.NET/Client key
			//ParseClient.Initialize ("APPLICATION_ID", ".NET_KEY");
			ParseClient.Initialize (Constants.ApplicationId, Constants.Key);
		}

		public async Task<List<TodoItem>> GetAll () 
		{
			var query = ParseObject.GetQuery ("Task").OrderBy ("Title");
			var ie = await query.FindAsync ();

			var tl = new List<TodoItem> ();
			foreach (var t in ie) {
				tl.Add (mConvertFactory.Convert (t));
			}

			return tl;
		}

		async public override Task<List<TodoItem>> RefreshDataAsync()
		{
			var query = ParseObject.GetQuery ("Task").OrderBy ("Title");
			var ie = await query.FindAsync ();

			var Items = new List<TodoItem> ();
			foreach (var t in ie) {
				Items.Add (mConvertFactory.Convert (t));
			}

			return Items;
		}

		public override async Task SaveItemAsync(TodoItem todoItem)
		{
			await mConvertFactory.Convert (todoItem).SaveAsync ();
		}

		public override async Task<TodoItem> GetItemAsync(string id)
		{
			var query = ParseObject.GetQuery("Task").WhereEqualTo("objectId", id);
			var t = await query.FirstAsync();
			return mConvertFactory.Convert (t);
		}

		public override async Task DeleteItemAsync(TodoItem item)
		{
			try 
			{
				await mConvertFactory.Convert(item).DeleteAsync();
			} 
			catch (Exception e) 
			{
				Console.Error.WriteLine(@"				ERROR {0}", e.Message);
			}
		}

	}
}

