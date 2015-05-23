using System;
using System.Threading.Tasks;

namespace DailyValue
{
	public interface IParseAdapter<M>
	{		
		string GetClassName ();
		string GetIdField ();
		string GetSortField ();

		M From (Object o);
		Object Parse (M model);
	}
}

