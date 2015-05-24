using System;
using Newtonsoft.Json;

namespace DailyValue
{
	public class TodoItem
	{
		public const string CLASS_NAME = "Task";

		public TodoItem ()
		{
		}

		[JsonProperty(PropertyName = "Title")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "Description")]
		public string Notes { get; set; }

		[JsonProperty(PropertyName = "IsDone")]
		public bool Done { get; set; }
	}
}

