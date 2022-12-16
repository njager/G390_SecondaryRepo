using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    public string cName;
    public TestController controller;

    void Start()
    {
        controller.CallBark(Speak);
    }

    public void Speak()
    {
        Debug.Log("Hi my name is: " + cName);
    }

}
