using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public enum EventType
{
    START,
    CONTINUE,
    PAUSE,
    STOP
}

public class EventManager
{
    private static readonly IDictionary<EventType, UnityEvent> dictionary = new Dictionary<EventType, UnityEvent>();


    public static void Subscribe(EventType eventType, UnityAction unityAction)
    {
        if(dictionary.ContainsKey(eventType))
        {
            
        }
    }

    public static void UnSubscribe(EventType eventType, UnityAction unityAction)
    {
    
    }

    public static void Publish(EventType eventType)
    {

    }

    public interface EventListenerBase
    {

    }
    public interface EventListener<T> : EventListenerBase
    {
        void OnEvent(T eventType);
    }
}
