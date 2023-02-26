using UnityEngine;
using UnityEngine.InputSystem;

namespace Main.Character.Module.MoveModule.TargetPosition
{
    public class TargetIsMooseClick : MonoBehaviour
    {
        private TargetPositionInput input;

        private AVector2 _moveToPosition;

        private Camera _mainCamera;
    
        private void Awake()
        {
            input = new TargetPositionInput();
            input.InputWorldPosition.InputCli.started += setTargetPosition;
            _mainCamera = Camera.main;
            _moveToPosition = GetComponent<AVector2>();
        }

        private void OnEnable()
        {
            input.InputWorldPosition.Enable();
        }

        private void OnDisable()
        {
            input.InputWorldPosition.Disable();
        }

        private void setTargetPosition(InputAction.CallbackContext context)
        {
            _moveToPosition.SetVector2(_mainCamera.ScreenToWorldPoint(input.InputWorldPosition.Position.ReadValue<Vector2>()));
        }


    }
}
