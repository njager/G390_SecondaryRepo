using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLerper : MonoBehaviour
{
    public Transform cubeTrans;
    public Vector3 startPos, endPos;
    [Range(0, 1)] public float percent = 0f;

    public Color colorA, colorB;

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(startPos, endPos);

        Vector3 lerpPosition = Vector3.Lerp(startPos, endPos, percent);
        Gizmos.color = Color.Lerp(colorA, colorB, percent);
        Gizmos.DrawSphere(lerpPosition, 1f);
    }
    private void Update()
    {
        
        float elapsedTime = Time.time;
        cubeTrans.position = Vector3.LerpUnclamped(startPos, endPos, (Mathf.Sin(elapsedTime) + 1) * 0.5f);
    }
}
