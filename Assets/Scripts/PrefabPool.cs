using System.Collections.Generic;
using UnityEngine;

public class PrefabPool<T> where T:MonoBehaviour, IPoolItem {

	protected string PresenterPrefabPath =  "";

	MonoBehaviour _owner       = null;
	GameObject   _prefab       = null;
	Queue<T>     _readyObjects = new Queue<T>();

	public virtual void Init() {
		_prefab = Resources.Load<GameObject>(PresenterPrefabPath);
		if ( _prefab == null ) {
			Debug.LogErrorFormat("PrefabPool: cannot load prefab from resources. Path: {0}", PresenterPrefabPath);
		}
	}

	public virtual T Get() {
		if (_readyObjects.Count > 0 ) {
			return _readyObjects.Dequeue();
		}
		return GetNew();
	}

	public virtual void Return(T item) {
		item.DeInit();
		_readyObjects.Enqueue(item);
	}

	protected virtual T GetNew() {
		var instance = Object.Instantiate(_prefab);
		var c = instance.GetComponent<T>();
		return c;
	}
}

public interface IPoolItem {
	void DeInit();
}
