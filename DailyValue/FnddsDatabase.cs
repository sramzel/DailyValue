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

		public FnddsDatabase (BaseParseStorage<MainFoodDesc> mfdStorage)
		{
			MainFoodDesc = mfdStorage;	
		}
	}
}

