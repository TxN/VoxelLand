using System.Xml;

using UnityEngine;

namespace SMGCore.Utils.Xml {
	public static class XmlElementExtensions {
	
		public static void AddAttrValue(this XmlElement elem, string name, string value) {
			var attr = elem.OwnerDocument.CreateAttribute(name);
			attr.Value = value;
			elem.Attributes.Append(attr);
		}
		
		public static void AddAttrValue(this XmlElement elem, string name, int value) {
			elem.AddAttrValue(name, value.ToString());
		}
		
		public static void AddAttrValue(this XmlElement elem, string name, uint value) {
			elem.AddAttrValue(name, value.ToString());
		}
		
		public static void AddAttrValue(this XmlElement elem, string name, long value) {
			elem.AddAttrValue(name, value.ToString());
		}
		
		public static void AddAttrValue(this XmlElement elem, string name, ulong value) {
			elem.AddAttrValue(name, value.ToString());
		}
		
		public static void AddAttrValue(this XmlElement elem, string name, bool value) {
			elem.AddAttrValue(name, value.ToString());
		}
		
		public static void AddAttrValue(this XmlElement elem, string name, float value) {
			elem.AddAttrValue(name, value.ToString());
		}
		
	}
}
