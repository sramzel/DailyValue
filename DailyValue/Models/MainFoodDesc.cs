using System;
using Newtonsoft.Json;

namespace DailyValue
{
	public class MainFoodDesc
	{
		public const string CLASS_NAME = "MainFoodDesc";

		public MainFoodDesc ()
		{
		}

		[JsonProperty(PropertyName = "mainFoodDescription")]
		public string MainFoodDescription { get; set; }

		[JsonProperty(PropertyName = "abbreviatedDescription")]
		public string AbbreviatedDescription { get; set; }

		[JsonProperty(PropertyName = "foodCode")]
		public long FoodCode { get; set; }
	}
}

