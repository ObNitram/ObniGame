using UnityEngine;

namespace Main.Character.Module.LookModule
{
    public class LookToPositionLazy : MonoBehaviour
    {
        [SerializeField] private AVector2 _output;
        private Vector2 _targetPosition;

     


        public void SetTargetPosition(Vector2 targetPosition)
        {
            _targetPosition = targetPosition;
        }

        private void Update()
        {
            _output.SetVector2((_targetPosition - (Vector2)transform.position));
        }
    }
}
