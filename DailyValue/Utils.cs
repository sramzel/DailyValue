using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DailyValue
{
	public class Utils
	{
		public static T DeserializeObject<T> (IList<KeyValuePair<string, Object>> value){
			var d = new Dictionary<string, Object> ();
			foreach (KeyValuePair<string, Object> kv in value) {
				d[kv.Key] = kv.Value;
			}
			return JsonConvert.DeserializeObject<T> (JsonConvert.SerializeObject (d));
		}
	}
}

