using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplayer : MonoBehaviour
{
    public string[] allDisplayText;
    public NumberRange counter;
    public Timer timer;
    public float displaySpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        timer.SetTimer(displaySpeed, SomeFunction);
        counter.MaxValue = allDisplayText.Length;
        counter.MinValue = 0;

        counter.OnMaxReached.AddListener(SomeOtherFunction);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            TesterActivate();
        }
    }
    string UpdateStringFromnextIndex()
    {
        return "";
    }

    void SomeFunction()
    {
        print("This is the first test line from function one");
        print("This is the second test line from function one");
        displaySpeed++;
    }
    public void TesterActivate()
    {
        timer.SetTimer(displaySpeed, ActiveText);
        counter.OnMaxReached.AddListener(SomeOtherFunction);
    }
    void ActiveText()
    { 
        print(allDisplayText[0]);
    }

    public void SomeOtherFunction() => print(allDisplayText[1]);
}
