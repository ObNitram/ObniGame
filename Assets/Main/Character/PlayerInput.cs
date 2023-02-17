using Main.Character.Module;
using UnityEngine;

namespace Main.Character
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private AVector2 directMove;
        [SerializeField] private AVector2 directLook;

        public bool _isOnMoose = true;

        private PlayerInputManager playerInputManager;
        private Camera _camera;
        private Vector2 _targetLook;

        private bool _mustLook;

        private void Awake()
        {
            directMove = GetComponent<AVector2>();
            _camera = Camera.main;

            playerInputManager = new PlayerInputManager();
            playerInputManager.Player.MustLook.performed += (_) => _mustLook = true;
            playerInputManager.Player.MustLook.canceled += (_) => _mustLook = false;
        }

        private void Start()
        {
            playerInputManager = new PlayerInputManager();
            playerInputManager.Player.MustLook.performed += (_) => _mustLook = true;
            playerInputManager.Player.MustLook.canceled += (_) => _mustLook = false;
            OnEnable();
        }

        private void OnEnable()
        {
            playerInputManager.Player.Enable();
            playerInputManager.Player.Look.Enable();
        }

        private void OnDisable()
        {
            playerInputManager.Player.Disable();
            playerInputManager.Player.Look.Disable();
        }


        private void GetLookPosition()
        {
            _targetLook = playerInputManager.Player.Look.ReadValue<Vector2>();

            if (!_isOnMoose) return;
            var position = transform.position;
            Vector2 objectPos = new Vector2(position.x, position.y);
            _targetLook = _camera.ScreenToWorldPoint(_targetLook);
            _targetLook -= objectPos;
            _targetLook.Normalize();
        }

        void Update()
        {
            Vector2 moveDirection = playerInputManager.Player.Move.ReadValue<Vector2>();
            directMove.SetVector2(moveDirection);

            if (_mustLook)
            {
                GetLookPosition();
                directLook.SetVector2(_targetLook);
            }
            else
            {
                directLook.SetVector2(moveDirection);
            }
            
        }
    }
}