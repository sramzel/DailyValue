using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DailyValue
{
	public abstract class IParseStorage<M>
	{
		public abstract Task<List<M>> RefreshDataAsync();

		public abstract Task<M> GetItemAsync (string id);

		public abstract Task SaveItemAsync (M item);

		public abstract Task DeleteItemAsync (M id);

		public abstract PclParseObject CreateObject ();

		public static M From (PclParseObject po){
			string json = JsonConvert.SerializeObject (po);
			return JsonConvert.DeserializeObject<M> (json);
		}

		public static PclParseObject Parse(M o){
			string json = JsonConvert.SerializeObject (o);
			Dictionary<string, Object> d = JsonConvert.DeserializeObject<Dictionary<string, Object>> (json);
			var po = App.ParseStorage.CreateObject ();
			foreach (string key in d.Keys){
				po [key] = d [key];
			}
			return po;
		}
	}
}

