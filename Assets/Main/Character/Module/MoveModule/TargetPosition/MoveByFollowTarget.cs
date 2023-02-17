using UnityEngine;

namespace Main.Character.Module.MoveModule.TargetPosition
{
    public class MoveByFollowTarget : MonoBehaviour
    {
        public Transform _target;
        private AVector2 moveToPosition;

        private void Awake()
        {
            moveToPosition = GetComponent<AVector2>();
        }

        // Update is called once per frame
        void Update()
        {
            moveToPosition.SetVector2(_target.position);
        }
    }
}
