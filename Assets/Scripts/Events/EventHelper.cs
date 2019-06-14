using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EventSys
{
	public class EventHelper : MonoBehaviour
	{

		[Serializable]
		public class EventData
		{
			public string Name = string.Empty;
			public Type Type = null;
			public List<MonoBehaviour> MonoWatchers = new List<MonoBehaviour>(100);
			public List<string> OtherWatchers = new List<string>(100);

			public EventData(Type type)
			{
				Type = type;
				Name = type.ToString();
			}
		}

		public bool AutoFill {
			get {
				return false;
			}
		}

		public List<EventData> Events = new List<EventData>(100);

		Dictionary<Type, string> _typeCache = new Dictionary<Type, string>();
		float _cleanupTimer = 0;

		void Awake()
		{
			DontDestroyOnLoad(gameObject);
			SubscribeToLogged();
		}

		void OnEnable()
		{
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		void OnDisable()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}

		void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			EventManager.Instance.CheckHandlersOnLoad();
		}

		void SubscribeToLogged()
		{
			// Subscribe to some events 
		}

		void SubscribeToLog<T>() where T : struct
		{
			EventManager.Subscribe<T>(this, OnLog);
		}

		void OnLog<T>(T ev) where T : struct
		{
		}

		void Update()
		{
			TryCleanUp();
			if (AutoFill) {
				Fill();
			}
		}

		void TryCleanUp()
		{
			if (_cleanupTimer > EventManager.CleanUpInterval) {
				EventManager.Instance.CleanUp();
				_cleanupTimer = 0;
			} else {
				_cleanupTimer += Time.deltaTime;
			}
		}

		[ContextMenu("Fill")]
		public void Fill()
		{
			var handlerIter = EventManager.Instance.Handlers.GetEnumerator();
			while (handlerIter.MoveNext()) {
				var pair = handlerIter.Current;
				var eventData = GetEventData(pair.Key);
				if (eventData == null) {
					eventData = new EventData(pair.Key);
					Events.Add(eventData);
				}
				FillEvent(pair.Value, eventData);
			}
		}

		void FillEvent(HandlerBase handler, EventData data)
		{
			data.MonoWatchers.Clear();
			data.OtherWatchers.Clear();
			var watchIter = handler.Watchers.GetEnumerator();
			while (watchIter.MoveNext()) {
				var item = watchIter.Current;
				if (item is MonoBehaviour) {
					data.MonoWatchers.Add(item as MonoBehaviour);
				} else {
					data.OtherWatchers.Add(item != null ? GetTypeNameFromCache(item.GetType()) : "null");
				}
			}
		}

		EventData GetEventData(Type type)
		{
			var iter = Events.GetEnumerator();
			while (iter.MoveNext()) {
				if (iter.Current.Type == type) {
					return iter.Current;
				}
			}
			return null;
		}

		string GetTypeNameFromCache(Type type)
		{
			string name = string.Empty;
			if (!_typeCache.TryGetValue(type, out name)) {
				name = type.ToString();
				_typeCache.Add(type, name);
			}
			return name;
		}
	}
}