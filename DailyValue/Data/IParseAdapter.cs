using System;
using System.Threading.Tasks;

namespace DailyValue
{
	public interface IParseAdapter<M>
	{		
		string ClassName {
			get;
		}

		string IdField {
			get;
		}

		M From (IParseObject o);
		IParseObject Parse (M model);
	}
}

