using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotPlotter : MonoBehaviour
{
    [Range(2, 60)] public int numDots = 8;
    [Range(0, 5)] public float radius = 1f;

    private void OnDrawGizmos()
    {
        Transform trans = transform;
        Gizmos.color = Color.red;

        Vector2[] dots = new Vector2[numDots];
        for (int i = 0; i < numDots; i++)
        {
            //calucate the roation
            dots[i] = MathUtils.AngToDir(((float)i / (float)numDots) * MathUtils.TAU) * radius;
            //draw the dot
            Gizmos.DrawSphere((Vector3)dots[i] + trans.position, 0.05f);
        }
    }
}
