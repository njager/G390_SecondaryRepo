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

    
}


