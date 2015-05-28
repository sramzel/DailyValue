using System;
using System.Collections.Generic;
namespace DailyValue
{
	public class FnddsDatabase
	{
		public BaseParseStorage<MainFoodDesc> MainFoodDesc {
			get;
			private set;
		}

		public BaseParseStorage<FoodWeights> FoodWeights {
			get;
			private set;
		}

		public FnddsDatabase (BaseParseStorage<MainFoodDesc> mfdStorage, BaseParseStorage<FoodWeights> fwStorage)
		{
			MainFoodDesc = mfdStorage;	
			FoodWeights = fwStorage;	
		}
	}
}

