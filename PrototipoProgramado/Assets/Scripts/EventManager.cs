using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour 
{
    private Dictionary <string, UnityEvent> eventDictionary;
    private Dictionary<string, TransformUnityEvent> transformEventDictionary;
    private static EventManager eventManager;
    public static TerminalEmulator terminal;

    // singleton
    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init (); 
                }
            }

            return eventManager;
        }
    }

    private void Awake() {
        terminal = GetComponentInChildren<TerminalEmulator>();
    }

    // instantiate the dictionary
    void Init ()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
        if (transformEventDictionary == null)
        {
            transformEventDictionary = new Dictionary<string, TransformUnityEvent>();
        }
    }

    // listen for events
    public static void StartListening (string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.AddListener (listener);
        } 
        else
        {
            thisEvent = new UnityEvent ();
            thisEvent.AddListener (listener);
            instance.eventDictionary.Add (eventName, thisEvent);
        }
    }

    public static void StartListeningTransform(string eventName, UnityAction<Transform> listener)
    {
        TransformUnityEvent thisEvent = null;
        if (instance.transformEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new TransformUnityEvent();
            thisEvent.AddListener(listener);
            instance.transformEventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening (string eventName, UnityAction listener)
    {
        if (eventManager == null) return;
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.RemoveListener (listener);
        }
    }

    public static void TriggerEvent (string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.Invoke ();
        }

        terminal.PrintEvent(eventName);
    }

    public static void TriggerEventTransform(string eventName, Transform t)
    {
        TransformUnityEvent thisEvent = null;
        if (instance.transformEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(t);
        }

        terminal.PrintEvent(eventName);
    }

}