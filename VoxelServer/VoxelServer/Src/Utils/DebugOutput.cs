#if UNITY_2017_3_OR_NEWER
using UnityEngine;
#endif

public static class DebugOutput {
	public static void LogFormat(string message, params object[] p) {
#if UNITY_2017_3_OR_NEWER
		Debug.LogFormat(message, p);
#else
		System.Console.WriteLine(message, p);
#endif
	}

	public static void LogWarningFormat(string message, params object[] p) {
#if UNITY_2017_3_OR_NEWER
		Debug.LogWarningFormat(message, p);
#else
		var str = string.Format(message, p);
		System.Console.WriteLine($"[WARN]: {str}");
#endif
	}

	public static void LogErrorFormat(string message, params object[] p) {
#if UNITY_2017_3_OR_NEWER
		Debug.LogWarningFormat(message, p);
#else
		var str = string.Format(message, p);
		System.Console.WriteLine($"[ERR]: {str}");
#endif
	}

	public static void Log(string message) {
#if UNITY_2017_3_OR_NEWER
		Debug.Log(message);
#else
		System.Console.WriteLine(message);
#endif
	}

	public static void LogWarning(string message) {
#if UNITY_2017_3_OR_NEWER
		Debug.LogWarning(message);
#else
		System.Console.WriteLine($"[WARN]: {message}");
#endif
	}

	public static void LogError(string message) {
#if UNITY_2017_3_OR_NEWER
		Debug.LogError(message);
#else
		System.Console.WriteLine($"[ERR]: {message}");
#endif
	}

	public static void LogError(object message) {
#if UNITY_2017_3_OR_NEWER
		Debug.LogError(message);
#else
		System.Console.WriteLine($"[ERR]: {message.ToString()}");
#endif
	}
}
