using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    float startTime;
    float currentTime;
    bool isPaused = false;
    bool shouldRepeat;

    public Action OnTimerCompleted;
    public Action OnTimerPaused;
    public Action OnTimerStarted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 0f && !isPaused) 
        {
            currentTime -= Time.deltaTime;

            if(currentTime <= 0f)
            {
                OnTimerCompleted();
                if (shouldRepeat)
                {
                    ResetTimer();
                }
            }
        }
    }
    void ToggleTimerPaused()
    {
        if (isPaused)
        {
            OnTimerStarted?.Invoke();
            isPaused = false;
        }
    }

    public void SetTimer(float newSeconds, Action timerCompletedCallback)
    {
        startTime = newSeconds;
        currentTime = startTime;
        OnTimerCompleted += timerCompletedCallback;
    }

    public void ResetTimer() => currentTime = startTime;
}
