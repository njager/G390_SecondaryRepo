using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public float explosionRadius;
    public SphereCollider explosionCollider;
    public GameObject[] explosionTargets = new GameObject[5];

    // Update is called once per frame
    void Update()
    {
        explosionCollider.radius = explosionRadius;

        //draw a line to every explosionTarget from the object this script is attached to
        foreach(GameObject target in explosionTargets)
        {
            if (!target)
            {
                continue;
            }
            Vector3 targetPosition = target.transform.position;
            //Draw a line from the grenade to each target if it is valid
            VectorDrawer.DebugDrawVector(transform.position, target.transform.position, Color.red);
            //Draw a line in the direction the targets will move if the grenade explodes
            VectorDrawer.DebugDrawOffsetVector(targetPosition, (targetPosition - transform.position).normalized, Color.magenta);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space pressed");
            Detonate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If this gameobject isn't part of the array, add it to the array
        if(!CheckIfItemInArray(other.gameObject, explosionTargets))
        {
            int emptyIndex = GetFirstEmptyIndex(explosionTargets);
            if(emptyIndex > -1)
            {
                explosionTargets[emptyIndex] = other.gameObject;
            }
            else
            {
                print("No room in the array!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(CheckIfItemInArray(other.gameObject, explosionTargets))
        {
            explosionTargets[FindItemIndex(other.gameObject, explosionTargets)] = null;
        }
    }

    int FindItemIndex(GameObject item, GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if(array[i] && array[i].Equals(item))
            {
                return i;
            }
        }
        return -1;
    }

    bool CheckIfItemInArray(GameObject item, GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if(array[i] && array[i].Equals(item))
            {
                return true;    
            }
        }
        return false;
    }

    int GetFirstEmptyIndex(GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == null)
            {
                return i;
            }
        }

        return -1;
    }

    void Detonate()
    {
        //move all valid targets
        foreach(var target in explosionTargets)
        {
            Vector3 directionOfTravel = (target.transform.position - transform.position).normalized;
            target.GetComponent<TargetScript>().Move(directionOfTravel, 10f);
        }
    }
}
