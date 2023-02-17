using UnityEngine;

namespace Main.Character.Module.LookModule.DirectionLook
{
    public class LookByTransform2D : AVector2
    {
        public Vector2 lookDirection;
        
        public override void SetVector2(Vector2 direction)
        {
            if(direction == Vector2.zero) return;
            lookDirection = direction.normalized;
        }

        public override Vector2 GetVector2()
        {
            return lookDirection;
        }

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
        }
    }
}