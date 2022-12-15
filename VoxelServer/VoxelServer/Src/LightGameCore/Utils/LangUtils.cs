using System;
using System.Globalization;
using System.Collections.Generic;

using UnityEngine;

namespace SMGCore.Utils {
	public static class TimeUtils {
		static public DateTime GetOriginTime() {
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
		}

		static public int GetDateTimeDay(DateTime date_time) {
			var dday = (date_time - GetOriginTime()).TotalDays;
			return Mathf.FloorToInt((float)dday);
		}

		static public DateTime ConvertFromUnixTimestamp(long timestamp) {
			var origin = GetOriginTime();
			return origin.AddSeconds(timestamp);
		}
		
		static public long ConvertToUnixTimestamp(DateTime date) {
			var origin = GetOriginTime();
			return (long)Math.Floor((date - origin).TotalSeconds);
		}
	}

	public static class LangUtils {
		static HashSet<string> _hasDuplicatesCache = new HashSet<string>();
		
		static public byte[] StringToBytes(string text) {
			return System.Text.Encoding.UTF8.GetBytes(text);
		}

		static public string StringFromBytes(byte[] bytes) {
			return System.Text.Encoding.UTF8.GetString(bytes);
		}

		static public string StringToBase64(string text) {
			return Convert.ToBase64String(StringToBytes(text));
		}

		static public bool TryToDecodeStringFromBase64(string base64, out string result) {
			try {
				result = StringFromBytes(Convert.FromBase64String(base64));
				return true;
			} catch ( Exception ) {
				result = string.Empty;
				return false;
			}
		}

		static public string SafeDecodeStringFromBase64(string base64, string def) {
			string result;
			return TryToDecodeStringFromBase64(base64, out result)
				? result
				: def;
		}

		static public bool HasDuplicates(List<string> collection) {
			var set = _hasDuplicatesCache;
			set.Clear();
			foreach ( var item in collection ) {
				if ( !set.Add(item) ) {
					return true;
				}
			}
			return false;
		}

		static public void IncDictValue<TKey>(Dictionary<TKey, int> dict, TKey key, int count = 1) {
			if ( !dict.ContainsKey(key) ) {
				dict.Add(key, count);
			} else {
				dict[key] += count;
			}
		}

		static public T GetFromDict<T>(Dictionary<ushort, T> dict, ushort key, T def) {
			if ( dict == null ) throw new ArgumentNullException("dict");
			T result;
			return dict.TryGetValue(key, out result) ? result : def;
		}

		static public T GetFromDict<T>(Dictionary<int, T> dict, int key, T def) {
			if ( dict == null ) throw new ArgumentNullException("dict");
			T result;
			return dict.TryGetValue(key, out result) ? result : def;
		}

		static public T GetFromDict<T>(Dictionary<string, T> dict, string key, T def) {
			if ( dict == null ) throw new ArgumentNullException("dict");
			if ( key  == null ) throw new ArgumentNullException("key");
			T result;
			return dict.TryGetValue(key, out result) ? result : def;
		}

		static public TValue GetFromDict<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key, TValue def) {
			if ( dict == null ) throw new ArgumentNullException("dict");
			if ( key  == null ) throw new ArgumentNullException("key");
			TValue result;
			return dict.TryGetValue(key, out result) ? result : def;
		}

		static public T GetOrCreateFromDict<T>(Dictionary<int, T> dict, int key, Func<T> factory) {
			if ( dict    == null ) throw new ArgumentNullException("dict");
			if ( factory == null ) throw new ArgumentNullException("factory");
			T result;
			if ( dict.TryGetValue(key, out result) ) {
				return result;
			}
			result = factory();
			dict.Add(key, result);
			return result;
		}

		static public T GetOrCreateFromDict<T>(Dictionary<string, T> dict, string key, Func<T> factory) {
			if ( dict    == null ) throw new ArgumentNullException("dict");
			if ( key     == null ) throw new ArgumentNullException("key");
			if ( factory == null ) throw new ArgumentNullException("factory");
			T result;
			if ( dict.TryGetValue(key, out result) ) {
				return result;
			}
			result = factory();
			dict.Add(key, result);
			return result;
		}

		static public bool SafeParseInt(string str, out int result) {
			return int.TryParse(
				str, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
		}

		static public bool SafeParseFloat(string str, out float result) {
			return float.TryParse(
				str, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
		}

		static public void UpdateOrAdd(Dictionary<string, int> dict, string key, int value) {
			if ( dict.ContainsKey(key) ) {
				dict[key] += value;
			} else {
				dict.Add(key, value);
			}
		}
		
		static public void AddOrReplace<T>(Dictionary<string, T> dict, string key, T value) {
			dict.Remove(key);
			dict.Add(key, value);
		}
	}

	static class EnumerableUtils {
		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
			if ( source == null ) throw new ArgumentNullException("source");
			if ( action == null ) throw new ArgumentNullException("action");
			var iter = source.GetEnumerator();
			while ( iter.MoveNext() ) {
				action(iter.Current);
			}
		}

		public static bool ForEach<T>(this IEnumerable<T> source, Func<T, bool> action) {
			if ( source == null ) throw new ArgumentNullException("source");
			if ( action == null ) throw new ArgumentNullException("action");

			var iter = source.GetEnumerator();
			while ( iter.MoveNext() ) {
				if ( !action(iter.Current) ) {
					return false;
				}
			}
			return true;
		}

		public static T FirstOrDef<T>(this List<T> source) {
			if ( ( source != null ) && ( source.Count > 0 ) ) {
				return source[0];
			}
			return default(T);
		}

		public static T FirstOrDef<T>(this HashSet<T> source) {
			if ( (source != null) && (source.Count > 0) ) {
				var iter = source.GetEnumerator();
				if ( iter.MoveNext() ) {
					return iter.Current;
				}
			}
			return default(T);
		}
	}
}
