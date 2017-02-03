using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RayManager : MonoBehaviour {

    public static RayManager rayManager;
    public int requiredRayCount = 6;
    private int currentReflectedRayCount = 0;
    public UnityEvent OnReflectAll;
    public UnityEvent OnReflectionCancelled;
    public List<Transform> reflectionSenders;

    void Awake()
    {
        if (rayManager == null)
            rayManager = this;

        reflectionSenders = new List<Transform>();
    }

    public void RayReflected(Transform sender)
    {
        // Make sure we don't get duplicate reflections from the same mirror
        if(!reflectionSenders.Contains(sender))
        {
            //Debug.Log("Reflection received from " + sender.gameObject.name);
            reflectionSenders.Add(sender);

            if (currentReflectedRayCount < requiredRayCount)
                currentReflectedRayCount += 1;
        }

        if (currentReflectedRayCount >= requiredRayCount)
        {
            if (OnReflectAll != null)
                OnReflectAll.Invoke();
        }
    }
    
    public void RemoveReflections()
    {
        reflectionSenders.Clear();
        currentReflectedRayCount = 0;
        OnReflectionCancelled.Invoke();
    }
}
