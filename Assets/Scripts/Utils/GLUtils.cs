using UnityEngine;

public static class GLUtils
{
    // ######################################### FUNCTIONS ########################################

    public static void GLBegin(ref Material _Material, int _Mode, Color _Color)
    {
        _Material.SetPass(0);
        GL.PushMatrix();
        GL.LoadProjectionMatrix(Camera.main.projectionMatrix);
        GL.modelview = Camera.main.worldToCameraMatrix;
        GL.Begin(_Mode);
        GL.Color(_Color);
    }

    public static void GLEnd()
    {
        GL.End();
        GL.PopMatrix();
    }

    public static void GLRenderLine(Vector3 _A, Vector3 _B)
    {
        GL.Vertex3(_A.x, _A.y, _A.z);
        GL.Vertex3(_B.x, _B.y, _B.z);
    }

    public static void GLRenderTriangle(Vector3 _A, Vector3 _B, Vector3 _C)
    {
        GL.Vertex3(_A.x, _A.y, _A.z);
        GL.Vertex3(_B.x, _B.y, _B.z);

        GL.Vertex3(_B.x, _B.y, _B.z);
        GL.Vertex3(_C.x, _C.y, _C.z);

        GL.Vertex3(_C.x, _C.y, _C.z);
        GL.Vertex3(_A.x, _A.y, _A.z);
    }

    public static void GLRenderQuad(Vector3 _A, Vector3 _B, Vector3 _C, Vector3 _D)
    {
        GL.Vertex3(_A.x, _A.y, _A.z);
        GL.Vertex3(_B.x, _B.y, _B.z);
        GL.Vertex3(_C.x, _C.y, _C.z);
        GL.Vertex3(_D.x, _D.y, _D.z);
    }

    public static void GLRenderWirCube(Vector3 _TopA, Vector3 _TopB, Vector3 _TopC, Vector3 _TopD, Vector3 _BottomA, Vector3 _BottomB, Vector3 _BottomC, Vector3 _BottomD)
    {
        // Top quad
        GLRenderLine(_TopA, _TopB);
        GLRenderLine(_TopB, _TopC);
        GLRenderLine(_TopC, _TopD);
        GLRenderLine(_TopD, _TopA);

        // Bottom quad
        GLRenderLine(_BottomA, _BottomB);
        GLRenderLine(_BottomB, _BottomC);
        GLRenderLine(_BottomC, _BottomD);
        GLRenderLine(_BottomD, _BottomA);

        // Side Lines
        GLRenderLine(_TopA, _BottomA);
        GLRenderLine(_TopB, _BottomB);
        GLRenderLine(_TopC, _BottomC);
        GLRenderLine(_TopD, _BottomD);
    }

    public static void GLRenderCircle(Vector3 _Center, float _Radius, Quaternion _Rotation, int _Segments = 100, float _Angle = 360)
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
            GL.Vertex(_Rotation * prevPoint + _Center);
            GL.Vertex(_Rotation * newPoint + _Center);
            prevPoint = newPoint;
        }
    }

    public static void GLRenderWirSphere(Vector3 _Center, float _Radius, int _Segments = 100)
    {
        GLRenderCircle(_Center, _Radius, Quaternion.Euler(0, 0, 0), _Segments);
        GLRenderCircle(_Center, _Radius, Quaternion.Euler(90, 0, 0), _Segments);
        GLRenderCircle(_Center, _Radius, Quaternion.Euler(0, 90, 0), _Segments);
    }

    public static void GLRenderWirCylinder(Vector3 _Pos, Quaternion _Rotation, float _Radius, float _Height)
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
            GLRenderLine(minPoint - _Offset, maxPoint - _Offset);
            GLRenderLine(minPoint + _Offset, maxPoint + _Offset);
        }
        DrawSideLines(XOffset);
        DrawSideLines(ZOffset);

        // Draw circles at the ends
        Quaternion circleRotation = Quaternion.Euler(90, 0, 0);
        GLRenderCircle(minPoint, _Radius, _Rotation * circleRotation);
        GLRenderCircle(maxPoint, _Radius, _Rotation * circleRotation);
    }

    public static void GLRenderWirCapsule(Vector3 _Pos, Quaternion _Rotation, float _Radius, float _Height)
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
            GLRenderLine(minPoint - _Offset, maxPoint - _Offset);
            GLRenderLine(minPoint + _Offset, maxPoint + _Offset);
        }
        DrawSideLines(XOffset);
        DrawSideLines(ZOffset);

        // Function: Draw demi-circles
        void DrawHemisphereCircles(Vector3 _Point, float _Angle)
        {
            GLRenderCircle(_Point, _Radius, _Rotation, 100, _Angle);
            GLRenderCircle(_Point, _Radius, _Rotation * Quaternion.Euler(0, 90, 0), 100, _Angle);
        }
        DrawHemisphereCircles(minPoint, -180);
        DrawHemisphereCircles(maxPoint, 180);

        // Draw circles at the ends
        Quaternion circleRotation = Quaternion.Euler(90, 0, 0);
        GLRenderCircle(minPoint, _Radius, _Rotation * circleRotation);
        GLRenderCircle(maxPoint, _Radius, _Rotation * circleRotation);
    }
}
