using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventSys
{
	public class EventManager
	{

		public const float CleanUpInterval = 10.0f;

		static EventManager _instance = null;
		public static EventManager Instance {
			get {
				if (_instance == null) {
					_instance = new EventManager();
					_instance.AddHelper();
				}
				return _instance;
			}
		}

		public Dictionary<Type, HandlerBase> Handlers {
			get {
				return _handlers;
			}
		}

		Dictionary<Type, HandlerBase> _handlers = new Dictionary<Type, HandlerBase>(100);

		// Static helpers:
		// **********
		public static void Subscribe<T>(object watcher, Action<T> action) where T : struct
		{
			Instance.Sub(watcher, action);
		}

		public static void Unsubscribe<T>(Action<T> action) where T : struct
		{
			if (_instance != null) {
				Instance.Unsub(action);
			}
		}

		public static void Fire<T>(T args) where T : struct
		{
			Instance.FireEvent(args);
		}

		public static bool HasWatchers<T>() where T : struct
		{
			return Instance.HasWatchersDirect<T>();
		}
		// **********

		void Sub<T>(object watcher, Action<T> action)
		{
			HandlerBase handler = null;
			if (!_handlers.TryGetValue(typeof(T), out handler)) {
				handler = new Handler<T>();
				_handlers.Add(typeof(T), handler);
			}
			(handler as Handler<T>).Subscribe(watcher, action);
		}

		void Unsub<T>(Action<T> action)
		{
			HandlerBase handler = null;
			if (_handlers.TryGetValue(typeof(T), out handler)) {
				(handler as Handler<T>).Unsubscribe(action);
			}
		}

		void FireEvent<T>(T args)
		{
			HandlerBase handler = null;
			if (!_handlers.TryGetValue(typeof(T), out handler)) {
				handler = new Handler<T>();
				_handlers.Add(typeof(T), handler);
			}
			(handler as Handler<T>).Fire(args);
		}

		bool HasWatchersDirect<T>() where T : struct
		{
			HandlerBase container = null;
			if (_handlers.TryGetValue(typeof(T), out container)) {
				return (container.Watchers.Count > 0);
			}
			return false;
		}

		void AddHelper()
		{
			var go = new GameObject("[EventHelper]");
			go.AddComponent<EventHelper>();
		}

		public void CheckHandlersOnLoad()
		{
			var iter = _handlers.GetEnumerator();
			while (iter.MoveNext()) {
				iter.Current.Value.FixWatchers();
			}
		}

		public void CleanUp()
		{
			var iter = _handlers.GetEnumerator();
			while (iter.MoveNext()) {
				iter.Current.Value.CleanUp();
			}
		}
	}
}