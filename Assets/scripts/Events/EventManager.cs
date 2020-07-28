using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class freezeEffect:UnityEvent<float>
{ }

public class speedupEffect:UnityEvent<float,float>
{
}



public class EventManager : MonoBehaviour
{

    public static List<pickupBlock> freezeinvokers = new List<pickupBlock>();
    public static List<UnityAction<float>> freezeListeners = new List<UnityAction<float>>();

    public static List<pickupBlock> speedupInvokers = new List<pickupBlock>();
    public static List<UnityAction<float, float>> speedupListeners = new List<UnityAction<float, float>>();

    public static void addFreezeInvoker(pickupBlock script)
    {
        freezeinvokers.Add(script);
        foreach(UnityAction<float> listener in freezeListeners )
        {
            script.addlistener(listener);
        }
    }

    public static void addFreezeListener(UnityAction<float> handler)
    {
        freezeListeners.Add(handler);
        foreach(pickupBlock invoker in freezeinvokers)
        {
            invoker.addlistener(handler);
        }
    }

    public static void addspeedupInvoker(pickupBlock script)
    {
        speedupInvokers.Add(script);
        foreach(UnityAction<float,float> listener in speedupListeners)
        {
            script.addlistener(listener);
        }
    }

    public static void addspeedupListener(UnityAction<float,float> listener)
    {
        speedupListeners.Add(listener);
        foreach (pickupBlock invoker in speedupInvokers )
        {
            invoker.addlistener(listener);
        }
    }

    
}
