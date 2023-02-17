using System;
using Main.Character.Module;
using UnityEngine;

namespace Main.Character.MoveModule.DirectionMove
{
    [Serializable]
    public class MoveByTransform : AVector2
    {
        public float speed = 10f;
        private Vector2 moveDirection;

        public override void SetVector2(Vector2 direction)
        {
            moveDirection = direction.normalized;
        }

        public override Vector2 GetVector2()
        {
            return moveDirection;
        }

        private void LateUpdate()
        {
            transform.position += (Vector3)moveDirection * (speed * Time.deltaTime);
        }
        
    }
}
