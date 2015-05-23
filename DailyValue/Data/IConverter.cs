using System;

namespace DailyValue
{
	public interface IConverter
	{
		ConvertFrom (B b);
		B ConvertTo (A a);
	}
}

