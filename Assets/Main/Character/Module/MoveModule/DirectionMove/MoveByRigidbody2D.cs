using System;
using Main.Character.Module;
using UnityEngine;

namespace Main.Character.MoveModule.DirectionMove
{
    [Serializable]
    public class MoveByRigidbody2D : AVector2
    {
        public float speed = 100f;
        private Vector2 moveDirectionTarget;
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    
        public override void SetVector2(Vector2 direction)
        {
            moveDirectionTarget = direction.normalized;
        }

        public override Vector2 GetVector2()
        {
            return rb.velocity;
        }

        private void FixedUpdate()
        {
            rb.AddForce(moveDirectionTarget * (speed));
        }
    }
}
