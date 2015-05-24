using System;
using Parse;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DailyValue.iOS
{
	public class ParseObjectIOS : PclParseObject
	{
		private ParseObject parseObject;

		public ParseObjectIOS(ParseObject po){
			parseObject = po;
		}

		public ParseObjectIOS(String s){
			parseObject = new ParseObject (s);
		}

		public override string ObjectId {
			get { return parseObject.ObjectId; }
			set { parseObject.ObjectId = value; }
		}

		public override Object this[
			string key
		] { get{return parseObject [key];} set{parseObject [key] = value;} }
	
		public override Task SaveAsync(){
			return parseObject.SaveAsync ();
		}

		public override Task DeleteAsync(){
			return parseObject.DeleteAsync ();
		}

		public override ICollection<string> Keys{
			get{ return parseObject.Keys; }
		}
	}
}

