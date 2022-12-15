// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;

namespace UnityEngine {
	public sealed partial class Mesh : Object {
		public Vector3[] vertices {
			get { return null; }
			set { }
		}
		public Vector3[] normals {
			get { return null; }
			set { }
		}
		public Vector4[] tangents {
			get { return null; }
			set { }
		}
		public Vector2[] uv {
			get { return null; }
			set { }
		}
		public Vector2[] uv2 {
			get { return null; }
			set { }
		}
		public Vector2[] uv3 {
			get { return null; }
			set { }
		}
		public Vector2[] uv4 {
			get { return null; }
			set { }
		}
		public Vector2[] uv5 {
			get { return null; }
			set { }
		}
		public Vector2[] uv6 {
			get { return null; }
			set { }
		}
		public Vector2[] uv7 {
			get { return null; }
			set { }
		}

		internal void SetUVs(int v, List<Vector2> uVs) {
			throw new NotImplementedException();
		}

		public Vector2[] uv8 {
			get { return null; }
			set { }
		}
		public Color[] colors {
			get { return null; }
			set { }
		}
		public Color32[] colors32 {
			get { return null; }
			set { }
		}

		public void GetVertices(List<Vector3> vertices) {
		}

		public void SetVertices(List<Vector3> inVertices) {
		}

		public void SetVertices(List<Vector3> inVertices, int start, int length) {
		}

		public void SetVertices(Vector3[] inVertices) {

		}

		public void SetVertices(Vector3[] inVertices, int start, int length) {

		}

		public void GetNormals(List<Vector3> normals) {
		}

		public void SetNormals(List<Vector3> inNormals) {
		}

		public void Clear() {

		}

	/*	public static bool operator ==(Mesh m, bool b) {
			return (m != null) == b;
		}

		public static bool operator !=(Mesh m, bool b) {
			return (m == null) == b;
		}
		*/
	}
}
