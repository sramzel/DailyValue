using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DailyValue
{
	public abstract class PclParseObject
	{
		public abstract string ObjectId {
			get;
			set;
		}

		public abstract object this [string key] {
			get;
			set;
		}

		public abstract Task SaveAsync ();

		public abstract Task DeleteAsync ();

		public abstract ICollection<string> Keys {
			get;
		}

		[JsonExtensionData]
		public IDictionary<string, Object> SchemalessData{
			get {
				var d = new Dictionary<string, object>();
				foreach (string key in Keys) {
					d.Add(key, this [key]);
				}
				return d;
			}
			set {
				foreach (string key in value.Keys) {
					this [key] = value [key];
				}
			}
		}
	}
}
