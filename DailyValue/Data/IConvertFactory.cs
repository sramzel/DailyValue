using System;

namespace TodoXaml
{
	public interface IConvertFactory<A, B>
	{
		A Convert (B b);
		B Convert (A a);
	}
}

