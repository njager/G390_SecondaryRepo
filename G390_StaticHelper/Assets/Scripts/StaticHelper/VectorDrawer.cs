using UnityEngine;

public static class VectorDrawer
{
    public static void DebugDrawVector(Vector3 startPoint, Vector3 endPoint) => Debug.DrawLine(startPoint, endPoint);
    public static void DebugDrawVector(Vector3 startPoint, Vector3 endPoint, Color vectorColor) => Debug.DrawLine(startPoint, endPoint, vectorColor);
    public static void DebugDrawVector(Vector3 startPoint, Vector3 direction, float distance)
    {
        direction = direction.normalized;
        Debug.DrawLine(startPoint, direction * distance);
    }
    public static void DebugDrawVector(Vector3 startPoint, Vector3 direction, float distance, Color vectorColor)
    {
        direction = direction.normalized;
        Debug.DrawLine(startPoint, direction * distance, vectorColor);
    }
    public static void DebugDrawOffsetVector(Vector3 startPoint, Vector3 offset)
    {
        Debug.DrawLine(startPoint, startPoint + offset);
    }
    public static void DebugDrawOffsetVector(Vector3 startPoint, Vector3 offset, Color vectorColor)
    {
        Debug.DrawLine(startPoint, startPoint + offset, vectorColor);
    }
    public static void DrawVectorGizmo(Vector3 startPoint, Vector3 endPoint)
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(startPoint, endPoint);
    }
    public static void DrawVectorGizmo(Vector3 startPoint, Vector3 endPoint, Color vectorColor)
    {
        Gizmos.color = vectorColor;
        Gizmos.DrawLine(startPoint, endPoint);
        Gizmos.color = Color.white;
    }
    public static void DrawVectorGizmo(Vector2 startPoint, Vector2 endPoint, Color vectorColor)
    {
        Gizmos.color = vectorColor;
        Gizmos.DrawLine(startPoint, endPoint);
        Gizmos.color = Color.white;
    }
    public static void DrawBasisVectors(Vector3 origin, Vector3 right, Vector3 up, Vector3 forward)
    {
        DebugDrawOffsetVector(origin, right, Color.red);
        DebugDrawOffsetVector(origin, up, Color.green);
        DebugDrawOffsetVector(origin, forward, Color.blue);
    }
    public static void DrawBasisVectors(Transform transform)
    {
        Vector3 position = transform.position;
        DebugDrawOffsetVector(position, transform.right, Color.red);
        DebugDrawOffsetVector(position, transform.up, Color.green);
        DebugDrawOffsetVector(position, transform.forward, Color.blue);
    }
    public static void DrawBasisVectors(Vector2 origin, Vector2 right, Vector2 up)
    {
        DebugDrawOffsetVector(origin, right, Color.red);
        DebugDrawOffsetVector(origin, up, Color.green);
    }
    public static void DrawBasisVectorsGizmos(Vector3 origin, Vector3 right, Vector3 up, Vector3 forward)
    {
        Gizmos.color = Color.red;
        DrawVectorGizmo(origin, origin + right);
        Gizmos.color = Color.green;
        DrawVectorGizmo(origin, origin + up);
        Gizmos.color = Color.blue;
        DrawVectorGizmo(origin, origin + forward);
    }
}


