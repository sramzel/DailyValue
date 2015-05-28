using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DailyValue
{
	public class FoodWeights
	{
		public const string CLASS_NAME = "FoodWeights";

		public FoodWeights ()
		{
		}

		[JsonProperty(PropertyName = "foodDescription")]
		public IList<KeyValuePair<string, Object>> FD {
			set {
				var d = new Dictionary<string, Object> ();
				foreach (KeyValuePair<string, Object> kv in value) {
					d[kv.Key] = kv.Value;
				}
				FoodDescription = JsonConvert.DeserializeObject<MainFoodDesc> (JsonConvert.SerializeObject (d));
			}
		}

		[JsonProperty(PropertyName = "score")]
		public string Score { get; set; }

		[JsonProperty(PropertyName = "foodCode")]
		public long FoodCode { get; set; }

		public MainFoodDesc FoodDescription {
			get;
			set;
		}
	}
}

