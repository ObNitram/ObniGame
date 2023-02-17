using UnityEngine;

namespace Main.Character.Module.LookModule.DirectionLook
{
    public class LookByRigidbody2D :  AVector2
    {
        
        public float speed = 1f;
        public Vector2 lookDirection;
        private Rigidbody2D rb;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.None;
        }
        
        public override void SetVector2(Vector2 direction)
        {
            if(direction == Vector2.zero) return;
            lookDirection = direction.normalized;
        }

        public override Vector2 GetVector2()
        {
            return lookDirection;
        }

        private void FixedUpdate()
        {
            rb.MoveRotation(Quaternion.LookRotation(lookDirection, Vector3.forward));
        }
    }
}