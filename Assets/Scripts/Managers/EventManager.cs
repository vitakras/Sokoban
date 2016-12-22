using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{

	private Dictionary<int, UnityEvent> eventDictionary;

	private static EventManager eventManager;

	public static EventManager intance {
		get {
			if (!eventManager) {
				eventManager = FindObjectOfType (typeof(EventManager)) as EventManager;

				if (!eventManager) {
					Debug.LogError ("No GameObjects found with an EventManager");
				} else {
					eventManager.Init ();
				}
			}

			return eventManager;
		}
	}

	void Init ()
	{
		if (this.eventDictionary == null) {
			this.eventDictionary = new Dictionary<int, UnityEvent> ();
		}
	}

	public void RegisterAction (int eventName, UnityAction action)
	{
		UnityEvent unityEvent;

		if (this.eventDictionary.TryGetValue (eventName, out unityEvent)) {
			unityEvent.AddListener (action);
		} else {
			unityEvent = new UnityEvent ();
			unityEvent.AddListener (action);
			this.eventDictionary.Add (eventName, unityEvent);
		}
	}

	public void DeRegisterAction (int eventName, UnityAction action)
	{
		UnityEvent unityEvent;

		if (this.eventDictionary.TryGetValue (eventName, out unityEvent)) {
			unityEvent.RemoveListener (action);
		}

	}

	public void TriggerEvent (int eventName)
	{
		UnityEvent unityEvent;
		if (this.eventDictionary.TryGetValue (eventName, out unityEvent)) {
			unityEvent.Invoke ();
		}
	}
}
