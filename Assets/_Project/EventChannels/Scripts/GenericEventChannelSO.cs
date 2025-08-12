using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GenericEventChannelSO", menuName = "Scriptable Objects/GenericEventChannelSO")]
public class GenericEventChannelSO<T> : ScriptableObject
{
    public event Action<T> OnEventRaised;

    public void RaiseEvent(T value)
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke(value);
        }
    }
}
