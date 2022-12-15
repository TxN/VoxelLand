using System;
using System.Xml;
using System.Collections.Generic;
using System.Globalization;

using UnityEngine;

namespace SMGCore.Utils.Xml {
	public static class XmlNodeExtensions {
		
		public static bool TryGetAttrValue(this XmlNode node, string name, out bool result) {
			var attr = node.Attributes[name];
			if ( (attr != null) && bool.TryParse(attr.Value, out result) ) {
				return true;
			}
			result = false;
			return false;
		}
		
		public static bool TryGetAttrValue(this XmlNode node, string name, out int result) {
			var attr = node.Attributes[name];
			if ( (attr != null) && int.TryParse(attr.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result) ) {
				return true;
			}
			result = 0;
			return false;
		}
		
		public static bool TryGetAttrValue(this XmlNode node, string name, out uint result) {
			var attr = node.Attributes[name];
			if ( (attr != null) && uint.TryParse(attr.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result) ) {
				return true;
			}
			result = 0u;
			return false;
		}
		
		public static bool TryGetAttrValue(this XmlNode node, string name, out long result) {
			var attr = node.Attributes[name];
			if ( (attr != null) && long.TryParse(attr.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result) ) {
				return true;
			}
			result = 0;
			return false;
		}
		
		public static bool TryGetAttrValue(this XmlNode node, string name, out ulong result) {
			var attr = node.Attributes[name];
			if ( (attr != null) && ulong.TryParse(attr.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result) ) {
				return true;
			}
			result = 0ul;
			return false;
		}
		
		public static bool TryGetAttrValue(this XmlNode node, string name, out float result) {
			var attr = node.Attributes[name];
			if ( (attr != null) && float.TryParse(attr.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result) ) {
				return true;
			}
			result = 0.0f;
			return false;
		}

		public static bool TryGetAttrValue(this XmlNode node, string name, out double result) {
			var attr = node.Attributes[name];
			if ( (attr != null) && double.TryParse(attr.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result) ) {
				return true;
			}
			result = 0.0;
			return false;
		}
		
		public static bool TryGetAttrValue(this XmlNode node, string name, out string result) {
			var attr = node.Attributes[name];
			if ( attr != null ) {
				result = attr.Value;
				return true;
			}
			result = string.Empty;
			return false;
		}
		
		public static bool GetAttrValue(this XmlNode node, string name, bool def) {
			return node.TryGetAttrValue(name, out bool result) ? result : def;
		}
		
		public static int GetAttrValue(this XmlNode node, string name, int def) {
			return node.TryGetAttrValue(name, out int result) ? result : def;
		}

		public static uint GetAttrValue(this XmlNode node, string name, uint def) {
			return node.TryGetAttrValue(name, out uint result) ? result : def;
		}
		
		public static long GetAttrValue(this XmlNode node, string name, long def) {
			return node.TryGetAttrValue(name, out long result) ? result : def;
		}
		
		public static ulong GetAttrValue(this XmlNode node, string name, ulong def) {
			return node.TryGetAttrValue(name, out ulong result) ? result : def;
		}
		
		public static float GetAttrValue(this XmlNode node, string name, float def) {
			return node.TryGetAttrValue(name, out float result) ? result : def;
		}
		
		public static string GetAttrValue(this XmlNode node, string name, string def) {
			return node.TryGetAttrValue(name, out string result) ? result : def;
		}

		public static List<int> LoadNodeList(this XmlNode node, string name, string attrName, int attrDef) {
			var result = new List<int>();
			foreach ( XmlNode childNode in node.ChildNodes ) {
				if ( childNode.Name == name ) {
					result.Add(childNode.GetAttrValue(attrName, attrDef));
				}
			}
			return result;
		}

		public static List<int> LoadNodeList(this XmlNode node, string parentName, string name, string attrName, int attrDef) {
			var result = new List<int>();
			foreach ( XmlNode parentNode in node.ChildNodes ) {
				if ( parentNode.Name == parentName ) {
					foreach ( XmlNode childNode in parentNode.ChildNodes ) {
						if ( childNode.Name == name ) {
							result.Add(childNode.GetAttrValue(attrName, attrDef));
						}
					}
					break;
				}
			}
			return result;
		}

		public static List<string> LoadNodeList(this XmlNode node, string name, string attrName) {
			var result = new List<string>();
			foreach ( XmlNode childNode in node.ChildNodes ) {
				if ( childNode.Name == name ) {
					result.Add(childNode.GetNotEmptyStringAttr(attrName));
				}
			}
			return result;
		}
				
		public static List<T> LoadNodeRawList<T>(this XmlNode node, string name, Func<XmlNode,T> factory) {
			var result = new List<T>();
			foreach ( XmlNode childNode in node.ChildNodes ) {
				if ( childNode.Name == name ) {
					var val = factory(childNode);
					if ( val != null ) {
						result.Add(val);
					}
				}
			}
			return result;
		}

		public static List<T> LoadNodeRawList<T>(this XmlNode node, string parentName, string name, Func<XmlNode, T> factory) {
			var result = new List<T>();
			foreach ( XmlNode parentNode in node.ChildNodes ) {
				if ( parentNode.Name == parentName ) {
					foreach ( XmlNode childNode in parentNode.ChildNodes ) {
						if ( childNode.Name == name ) {
							var val = factory(childNode);
							if ( val != null ) {
								result.Add(val);
							}
						}
					}
					break;
				}
			}
			return result;
		}
		
		public static Dictionary<string, bool> LoadNodeDict(this XmlNode node, string name, bool def) {
			var result = new Dictionary<string, bool>();
			foreach ( XmlNode childNode in node.ChildNodes ) {
				if ( childNode.Name == name ) {
					var key = childNode.GetNotEmptyStringAttr("name");
					var value = childNode.GetAttrValue("value", def);
					result[key] = value;
				}
			}
			return result;
		}

		public static Dictionary<string, bool> LoadNodeDict(this XmlNode node, string parentName, string name, bool def) {
			var result = new Dictionary<string, bool>();
			foreach ( XmlNode parentNode in node.ChildNodes ) {
				if ( parentNode.Name == parentName ) {
					foreach ( XmlNode childNode in parentNode.ChildNodes ) {
						if ( childNode.Name == name ) {
							var key = childNode.GetNotEmptyStringAttr("name");
							var value = childNode.GetAttrValue("value", def);
							result[key] = value;
						}
					}
					break;
				}
			}
			return result;
		}

		public static Dictionary<string, int> LoadNodeDict(this XmlNode node, string name, int def) {
			var result = new Dictionary<string, int>();
			foreach ( XmlNode childNode in node.ChildNodes ) {
				if ( childNode.Name == name ) {
					var key = childNode.GetNotEmptyStringAttr("name");
					var value = childNode.GetAttrValue("value", def);
					result[key] = value;
				}
			}
			return result;
		}

		public static Dictionary<string, int> LoadNodeDict(this XmlNode node, string parentName, string name, int def) {
			var result = new Dictionary<string, int>();
			foreach ( XmlNode parentNode in node.ChildNodes ) {
				if ( parentNode.Name == parentName ) {
					foreach ( XmlNode childNode in parentNode.ChildNodes ) {
						if ( childNode.Name == name ) {
							var key = childNode.GetNotEmptyStringAttr("name");
							var value = childNode.GetAttrValue("value", def);
							result[key] = value;
						}
					}
					break;
				}
			}
			return result;
		}

		public static Dictionary<string, long> LoadNodeDict(this XmlNode node, string name, long def) {
			var result = new Dictionary<string, long>();
			foreach ( XmlNode childNode in node.ChildNodes ) {
				if ( childNode.Name == name ) {
					var key = childNode.GetNotEmptyStringAttr("name");
					var value = childNode.GetAttrValue("value", def);
					result[key] = value;
				}
			}
			return result;
		}
		
		public static Dictionary<string, string> LoadNodeDict(this XmlNode node, string name, string def) {
			var result = new Dictionary<string, string>();
			foreach ( XmlNode childNode in node.ChildNodes ) {
				if ( childNode.Name == name ) {
					var key = childNode.GetNotEmptyStringAttr("name");
					var value = childNode.GetAttrValue("value", def);
					result[key] = value;
				}
			}
			return result;
		}
		
		public static XmlNode SelectFirstNode(this XmlNode parent, string name) {
			if ( parent == null ) {
				return null;
			}
			foreach ( XmlNode childNode in parent.ChildNodes ) {
				if ( childNode.Name == name ) {
					return childNode;
				}
			}
			return null;
		}

		public static XmlNode SelectFirstNode(this XmlNode parent, string parentName, string name) {
			foreach ( XmlNode parentNode in parent.ChildNodes ) {
				if ( parentNode.Name == parentName ) {
					foreach ( XmlNode childNode in parentNode.ChildNodes ) {
						if ( childNode.Name == name ) {
							return childNode;
						}
					}
					break;
				}
			}
			return null;
		}
		
		public static bool HasAttrValue(this XmlNode node, string name) {
			return node.TryGetAttrValue(name, out string value);
		}
		
		public static string GetNotEmptyStringAttr(this XmlNode node, string name) {
			if ( node.TryGetAttrValue(name, out string result) && !string.IsNullOrEmpty(result) ) {
				return result;
			}
			throw new InvalidOperationException(string.Format("GetNotEmptyStringAttr: string attribute wrong({0})", name));
		}
		
		public static Vector2 CreateVectorFromNode(this XmlNode node) {
			float x = node.GetAttrValue("x", 0);
			float y = node.GetAttrValue("y", 0);
			return new Vector2(x, y);
		}
	}
}
