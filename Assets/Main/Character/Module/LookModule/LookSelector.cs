using UnityEngine;

namespace Main.Character.Module.LookModule
{
    public class LookSelector : MonoBehaviour
    {
        [SerializeField] private AVector2 _aDirectLook;
        [SerializeField] private AVector2 directMove;

        private Vector2 lookDirection;
        
        private void Update()
        {
            _aDirectLook.SetVector2(lookDirection != Vector2.zero
                ? lookDirection
                : directMove.GetVector2());
        }

        public void SetLookDirection(Vector2 direction)
        {
            lookDirection = direction;
        }

    }
}