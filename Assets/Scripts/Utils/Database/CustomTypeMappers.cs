using UnityEngine;

using LiteDB;

public static class CustomTypeMappers {

	public static void InitMappers() {
		Debug.Log("register mappers");
		BsonMapper.Global.RegisterType(
			vector => new BsonArray(new BsonValue[] { vector.x, vector.y, vector.z }),
			value => new Vector3((float)value.AsArray[0].AsDouble, (float)value.AsArray[1].AsDouble, (float)value.AsArray[2].AsDouble)
		);
	}
}
