using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
      private List<IObserver> observingClasses= new List<IObserver>();

    public void AddObservingClass(IObserver observingClass) 
    { 
        observingClasses.Add(observingClass);
    }

    public void RemoveObservingClass(IObserver observingClass) 
    { 
        observingClasses.Remove(observingClass);
    }

    protected void NotifyObservingClasses()
    {
        observingClasses.ForEach((observerClass) =>
        {
            observerClass.NotifyClass();
        });
    }


}
