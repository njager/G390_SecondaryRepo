using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealClock : MonoBehaviour
{
    const float hourRotation = 30f, minuteRotation = 6f;
    public Transform hourHandPivot, minuteHandPivot, secondHandPivot;
    // Update is called once per frame
    void Update()
    {
        var time = DateTime.Now;

        hourHandPivot.localRotation = Quaternion.Euler(0, hourRotation * time.Hour, 0);
        minuteHandPivot.localRotation = Quaternion.Euler(0, minuteRotation * time.Minute, 0);
        secondHandPivot.localRotation = Quaternion.Euler(0, minuteRotation * time.Second, 0);

    }
}
