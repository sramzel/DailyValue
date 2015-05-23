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

			// https://parse.com/apps/YOUR_APP_NAME/edit#app_keys
			// ApplicationId, Windows/.NET/Client key
			//ParseClient.Initialize ("APPLICATION_ID", ".NET_KEY");
			ParseClient.Initialize (Constants.ApplicationId, Constants.Key);
		}

		public async Task<List<M>> GetAll (IParseAdapter<M> descriptor) 
		{
			var query = ParseObject.GetQuery (descriptor.GetClassName()).OrderBy (descriptor.GetSortField());
			var ie = await query.FindAsync ();

			var tl = new List<M> ();
			foreach (var t in ie) {
				tl.Add (mConvertFactory.From (new ParseObjectIOS(t)));
			}

			return tl;
		}

		async public override Task<List<M>> RefreshDataAsync()
		{
			var query = ParseObject.GetQuery (mConvertFactory.GetClassName()).OrderBy (mConvertFactory.GetSortField());
			var ie = await query.FindAsync ();

			var Items = new List<M> ();
			foreach (var t in ie) {
				Items.Add (mConvertFactory.From (new ParseObjectIOS(t)));
			}

			return Items;
		}

		public override async Task SaveItemAsync(M todoItem)
		{
			await ((ParseObject) mConvertFactory.Parse (todoItem)).SaveAsync ();
		}

		public override async Task<M> GetItemAsync(string id)
		{
			var query = ParseObject.GetQuery(mConvertFactory.GetClassName()).WhereEqualTo(mConvertFactory.GetIdField(), id);
			var t = await query.FirstAsync();
			return mConvertFactory.From (new ParseObjectIOS(t));
		}

		public override async Task DeleteItemAsync(M item)
		{
			try 
			{
				await ((ParseObject) mConvertFactory.Parse(item)).DeleteAsync();
			} 
			catch (Exception e) 
			{
				Console.Error.WriteLine(@"				ERROR {0}", e.Message);
			}
		}

	}
}