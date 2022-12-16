using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class NumberRange : MonoBehaviour
{
    float min;
    float max;
    float currentValue;

    [SerializeField] public UnityEvent<float> OnCurrentChanged;
    [SerializeField] public UnityEvent OnMaxReached;
    [SerializeField] public UnityEvent OnMinReached;

    public float MinValue { get => min; set => min = value; }
    public float MaxValue { get => max; set => max = value; }
    public float CurrentValue
    {
        get => currentValue;
        set 
        {
            currentValue = Mathf.Clamp(value, min, max);
            OnCurrentChanged?.Invoke(currentValue);
            if(currentValue == max)
            {
                OnMaxReached?.Invoke();
            }
            if(currentValue == min)
            {
                OnMinReached?.Invoke();
            }
        }
    }
    

    //float GetMaxValue() => max;
   
}
