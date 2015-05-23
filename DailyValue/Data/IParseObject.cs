using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace DailyValue
{
	public interface IParseObject
	{
		string ObjectId {
			get;
			set;
		}

		object this [string key] {
			get;
			set;
		}
	}
}
