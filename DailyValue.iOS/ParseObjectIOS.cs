using System;
using Parse;
using System.Collections;
using System.Collections.Generic;

namespace DailyValue.iOS
{
	public class ParseObjectIOS : IParseObject
	{
		private ParseObject parseObject;

		public ParseObjectIOS(ParseObject po){
			parseObject = po;
		}

		public ParseObjectIOS(String s){
			parseObject = new ParseObject (s);
		}

		public string ObjectId {
			get { return parseObject.ObjectId; }
			set { parseObject.ObjectId = value; }
		}

		public virtual Object this[
			string key
		] { get{return parseObject [key];} set{parseObject [key] = value;} }
	}
}

