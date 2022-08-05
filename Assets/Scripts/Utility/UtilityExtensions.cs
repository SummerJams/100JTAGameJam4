using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilityExtensions 
{
    public static T[] GetComponentsOnlyInChildren<T>(Transform transform) where T:class
    {
        List<T> group = new List<T>();

        if (typeof(T).IsInterface 
            || typeof(T).IsSubclassOf(typeof(Component)) 
            || typeof(T) == typeof(Component)) 
        {
            foreach (Transform child in transform) 
            {
                group.AddRange (child.GetComponentsInChildren<T> ());
            }
        }
         
        return group.ToArray ();
    }
}
