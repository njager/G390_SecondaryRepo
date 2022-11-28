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
            Vector3 targetPosition = target.transform.position;
            //Draw a line from the grenade to each target if it is valid
            VectorDrawer.DebugDrawVector(transform.position, target.transform.position, Color.red);
            //Draw a line in the direction the targets will move if the grenade explodes
            VectorDrawer.DebugDrawVector(targetPosition, (targetPosition - transform.position).normalized, Color.magenta);
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
}
