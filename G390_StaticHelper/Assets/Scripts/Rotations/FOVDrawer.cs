using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FOVDrawer : MonoBehaviour
{
    [Range(0, 180)]public float fovRangeDeg = 45f;
    public float radius = 1f;
    float fovRangeRad => Mathf.Deg2Rad * fovRangeDeg;
    float fovHalfAng => fovRangeRad * 0.5f;

    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position, normal = -transform.forward, up = transform.up;

        float forwardAngle = MathUtils.DirToAngle(up);

        Vector3 leftLine = MathUtils.AngToDir(fovHalfAng + forwardAngle);
        Vector3 rightLine = MathUtils.AngToDir(-fovHalfAng + forwardAngle);

        Gizmos.DrawLine(origin, origin + leftLine * radius);
        Gizmos.DrawLine(origin, origin + rightLine * radius);
        Handles.DrawWireArc(origin, normal, leftLine, fovRangeDeg, radius);


    }
}
