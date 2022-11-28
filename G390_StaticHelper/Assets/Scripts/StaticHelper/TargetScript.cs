using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    bool shouldMove = false;
    Vector3 moveDirection;
    float currentSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            Move(moveDirection, currentSpeed);
        }
    }

    public void Move(Vector3 direction, float speed)
    {
        speed = Mathf.Abs(speed);
        
        if(speed > 0.5)
        {
            shouldMove = true;
            currentSpeed = speed;
        }
        moveDirection = direction;
        transform.position += moveDirection * speed * Time.deltaTime;
        currentSpeed -= 0.1f;
    }
}
