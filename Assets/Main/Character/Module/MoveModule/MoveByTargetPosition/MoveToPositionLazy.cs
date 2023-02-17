using UnityEngine;

namespace Main.Character.Module.MoveModule.MoveByTargetPosition
{
    public class MoveToPositionLazy : AVector2
    {
        private AVector2 directMove;
        private Vector2 _targetPosition;

        private void Awake()
        {
            directMove = GetComponent<AVector2>();   
        }


        public override void SetVector2(Vector2 targetPosition)
        {
            _targetPosition = targetPosition;
        }

        public override Vector2 GetVector2()
        {
            return directMove.GetVector2();
        }


        private void Update()
        {
            directMove.SetVector2((_targetPosition - (Vector2)transform.position));
        }
    }
}
