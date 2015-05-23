using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DailyValue
{
	public abstract class IParseStorage<M>
	{
		protected IParseAdapter<M> ParseFactory {
			get;
		}

		public IParseStorage(IParseAdapter<M> parseFactory){
			ParseFactory = parseFactory;
		}

		public abstract Task<List<M>> RefreshDataAsync();

		public abstract Task<M> GetItemAsync (string id);

		public abstract Task SaveItemAsync (M item);

		public abstract Task DeleteItemAsync (M id);

	}
}

