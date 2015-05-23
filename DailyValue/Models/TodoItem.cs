using System;
using Newtonsoft.Json;

namespace DailyValue
{
	public class TodoItem
	{
		public TodoItem ()
		{
		}

		[JsonProperty(PropertyName = "id")]
		public string ID { get; set; }

		[JsonProperty(PropertyName = "text")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "notes")]
		public string Notes { get; set; }

		[JsonProperty(PropertyName = "complete")]
		public bool Done { get; set; }

		public string GetClass(){
			return "Task";
		}

		public string GetIdField(){
			return "objectId";
		}

		public string GetSortField(){
			return "title";
		}
	}
}

