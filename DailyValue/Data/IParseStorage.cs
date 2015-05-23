using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DailyValue
{
	public abstract class IParseStorage<M>
	{
		protected IParseAdapter<M> mConvertFactory;

		public IParseStorage(IParseAdapter<M> parseFactory){
			mConvertFactory = parseFactory;
		}

		public abstract Task<List<M>> RefreshDataAsync();

		public abstract Task<M> GetItemAsync (string id);

		public abstract Task SaveItemAsync (M item);

		public abstract Task DeleteItemAsync (M id);

	}
}

