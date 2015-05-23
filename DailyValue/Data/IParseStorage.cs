using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoXaml
{
	public abstract class IParseStorage<M, P>
	{
		protected IConvertFactory<M, P> mConvertFactory;

		public IParseStorage(IConvertFactory<M, P> parseFactory){
			mConvertFactory = parseFactory;
		}

		public abstract Task<List<M>> RefreshDataAsync();

		public abstract Task<M> GetItemAsync (string id);

		public abstract Task SaveItemAsync (M item);

		public abstract Task DeleteItemAsync (M id);
	}
}

