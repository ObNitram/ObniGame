using System;
using Main.Weapon.SO_Weapon;
using UnityEngine;


namespace Main.Character.Module.LookModule
{
    public class LookToPositionPredictive : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _target;

        [SerializeField] private AVector2 _output;

        public WeaponSO weaponSO;

        private void Update()
        {
            GetPredictiveDirection();
        }

        private void GetPredictiveDirection()
        {
            Vector2 A = transform.position;
            Vector2 B = _target.position;
            Vector2 circleCenter = B + _target.velocity;
            float circleRadius = weaponSO.speed;

            //Debug.DrawRay(A, (B - A) * 100f, Color.blue);
            //Debug.DrawLine(B, circleCenter, Color.yellow);
            //Debug.DrawCircle(circleCenter, circleRadius);

            Vector2[] intersectionPointReturned = IntersectionLineCircle(A, B, circleCenter,
                circleRadius);

            if (intersectionPointReturned.Length == 0)
            {
                //_debugSpriteRenderer.color = Color.red;
                return;
            }


            //Vector2 direction1 = (Vector2)circleCenter - intersectionPointReturned[0];
            //Debug.DrawRay(A, direction1*100f, Color.green);

            Vector2 direction2 = circleCenter - intersectionPointReturned[1];
            Debug.DrawRay(A, direction2 * 100f, Color.green);

            _output.SetVector2(direction2);
        }


        public static Vector2[] IntersectionLineCircle(Vector2 A, Vector2 B, Vector2 centre, float radius)
        {
            Vector2[] result = new Vector2[2];
            Vector2 AB = B - A;
            float a = AB.x * AB.x + AB.y * AB.y;
            float b = 2 * AB.x * (A.x - centre.x) + 2 * AB.y * (A.y - centre.y);
            float c = centre.x * centre.x + centre.y * centre.y + A.x * A.x + A.y * A.y -
                      2 * (centre.x * A.x + centre.y * A.y) - radius * radius;
            float delta = b * b - 4 * a * c;

            if (delta < 0)
            {
                return Array.Empty<Vector2>(); // Return an empty vector array if there are no intersection points
            }
            else if (delta == 0)
            {
                float t = -b / (2 * a);
                result[0] = A + t * AB;
                return new[] { result[0] };
            }
            else
            {
                //float t1 = (-b + Mathf.Sqrt(delta)) / (2 * a);
                float t2 = (-b - Mathf.Sqrt(delta)) / (2 * a);
                //result[0] = A + t1 * AB;
                result[1] = A + t2 * AB;
                return result;
            }
        }
    }


    public abstract class Debug : UnityEngine.Debug
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static void DrawCircle(Vector3 position, float radius, int segments = 50)
        {
            DrawCircle(position, radius, Color.blue, segments);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static void DrawCircle(Vector3 position, float radius, Color color, int segments = 50)
        {
            // If either radius or number of segments are less or equal to 0, skip drawing
            if (radius <= 0.0f || segments <= 0)
            {
                return;
            }

            // Single segment of the circle covers (360 / number of segments) degrees
            float angleStep = (360.0f / segments);

            // Result is multiplied by Mathf.Deg2Rad constant which transforms degrees to radians
            // which are required by Unity's Mathf class trigonometry methods

            angleStep *= Mathf.Deg2Rad;

            // lineStart and lineEnd variables are declared outside of the following for loop
            Vector3 lineStart = Vector3.zero;
            Vector3 lineEnd = Vector3.zero;

            for (int i = 0; i < segments; i++)
            {
                // Line start is defined as starting angle of the current segment (i)
                lineStart.x = Mathf.Cos(angleStep * i);
                lineStart.y = Mathf.Sin(angleStep * i);


                // Line end is defined by the angle of the next segment (i+1)
                lineEnd.x = Mathf.Cos(angleStep * (i + 1));
                lineEnd.y = Mathf.Sin(angleStep * (i + 1));

                // Results are multiplied so they match the desired radius
                lineStart *= radius;
                lineEnd *= radius;

                // Results are offset by the desired position/origin 
                lineStart += position;
                lineEnd += position;

                // Points are connected using DrawLine method and using the passed color
                DrawLine(lineStart, lineEnd, color);
            }
        }
    }
}