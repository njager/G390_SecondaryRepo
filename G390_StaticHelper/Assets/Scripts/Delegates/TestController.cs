using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestController : MonoBehaviour
{
    public int health = 10;
    public Action AIBark;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            health--;
            print("Health = " + health);
            VFXManager.PlayEffect();
            SFXManager.PlaySound();
        }
    }

    void Bark()
    {
        print("I'm the boss!");
        AIBark();
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Test trigger on");
        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("Test trigger keyed");
            if (other.CompareTag("Minion"))
            {
                Debug.Log("Test trigger");
                Bark();
            }
            
        }
    }

    public void CallBark(Action barkCall)
    {
        AIBark += barkCall;
    }
    
}
