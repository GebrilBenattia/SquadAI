using UnityEngine;

public static class GizmosUtils
{
    // ######################################### FUNCTIONS ########################################

    public static void RenderTriangle(Vector3 _A, Vector3 _B, Vector3 _C)
    {
        Gizmos.DrawLine(_A, _B);
        Gizmos.DrawLine(_B, _C);
        Gizmos.DrawLine(_C, _A);
    }

    public static void RenderWirCube(Vector3 _TopA, Vector3 _TopB, Vector3 _TopC, Vector3 _TopD, Vector3 _BottomA, Vector3 _BottomB, Vector3 _BottomC, Vector3 _BottomD)
    {
        // Top quad
        Gizmos.DrawLine(_TopA, _TopB);
        Gizmos.DrawLine(_TopB, _TopC);
        Gizmos.DrawLine(_TopC, _TopD);
        Gizmos.DrawLine(_TopD, _TopA);

        // Bottom quad
        Gizmos.DrawLine(_BottomA, _BottomB);
        Gizmos.DrawLine(_BottomB, _BottomC);
        Gizmos.DrawLine(_BottomC, _BottomD);
        Gizmos.DrawLine(_BottomD, _BottomA);

        // Side Lines
        Gizmos.DrawLine(_TopA, _BottomA);
        Gizmos.DrawLine(_TopB, _BottomB);
        Gizmos.DrawLine(_TopC, _BottomC);
        Gizmos.DrawLine(_TopD, _BottomD);
    }

    public static void RenderCircle(Vector3 _Center, float _Radius, Quaternion _Rotation, int _Segments = 100, float _Angle = 360)
    {
        // Variables
        float angleStep = _Angle / _Segments;
        Vector3 prevPoint = Vector3.right * _Radius;

        // Loop on each segments
        for (int i = 1; i <= _Segments; i++)
        {

            // Calculate new point
            float angle = i * angleStep;
            Vector3 newPoint = Quaternion.Euler(0, 0, angle) * Vector3.right * _Radius;

            // Draw line
            Gizmos.DrawLine(_Rotation * prevPoint + _Center, _Rotation * newPoint + _Center);
            prevPoint = newPoint;
        }
    }

    public static void RenderWirCylinder(Vector3 _Pos, Quaternion _Rotation, float _Radius, float _Height)
    {
        // Variables
        Vector3 halfHeight = Vector3.up * (_Height / 2f);
        Vector3 minPoint = _Pos + _Rotation * (-halfHeight);
        Vector3 maxPoint = _Pos + _Rotation * halfHeight;
        Vector3 XOffset = _Rotation * Vector3.right * _Radius;
        Vector3 ZOffset = _Rotation * Vector3.forward * _Radius;

        // Function: Draw Side lines with an offset
        void DrawSideLines(Vector3 _Offset)
        {
            Gizmos.DrawLine(minPoint - _Offset, maxPoint - _Offset);
            Gizmos.DrawLine(minPoint + _Offset, maxPoint + _Offset);
        }
        DrawSideLines(XOffset);
        DrawSideLines(ZOffset);

        // Draw circles at the ends
        Quaternion circleRotation = Quaternion.Euler(90, 0, 0);
        RenderCircle(minPoint, _Radius, _Rotation * circleRotation);
        RenderCircle(maxPoint, _Radius, _Rotation * circleRotation);
    }

    public static void RenderWirCapsule(Vector3 _Pos, Quaternion _Rotation, float _Radius, float _Height)
    {
        // Variables
        Vector3 halfHeight = Vector3.up * (_Height / 2f - _Radius);
        Vector3 minPoint = _Pos + _Rotation * (-halfHeight);
        Vector3 maxPoint = _Pos + _Rotation * halfHeight;
        Vector3 XOffset = _Rotation * Vector3.right * _Radius;
        Vector3 ZOffset = _Rotation * Vector3.forward * _Radius;

        // Function: Draw Side lines with an offset
        void DrawSideLines(Vector3 _Offset)
        {
            Gizmos.DrawLine(minPoint - _Offset, maxPoint - _Offset);
            Gizmos.DrawLine(minPoint + _Offset, maxPoint + _Offset);
        }
        DrawSideLines(XOffset);
        DrawSideLines(ZOffset);

        // Function: Draw demi-circles
        void DrawHemisphereCircles(Vector3 _Point, float _Angle)
        {
            RenderCircle(_Point, _Radius, _Rotation, 100, _Angle);
            RenderCircle(_Point, _Radius, _Rotation * Quaternion.Euler(0, 90, 0), 100, _Angle);
        }
        DrawHemisphereCircles(minPoint, -180);
        DrawHemisphereCircles(maxPoint, 180);

        // Draw circles at the ends
        Quaternion circleRotation = Quaternion.Euler(90, 0, 0);
        RenderCircle(minPoint, _Radius, _Rotation * circleRotation);
        RenderCircle(maxPoint, _Radius, _Rotation * circleRotation);
    }
}
