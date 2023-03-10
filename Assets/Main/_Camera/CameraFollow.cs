using UnityEngine;

namespace Main._Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float _smoothTime = 0.3f;
        //[SerializeField] private float _maxRange = 10.0f;
        

        private Vector3 velocity = Vector3.zero;

        private bool _mustLook;

        //private Camera _camera;
        //private InputManager _inputManager;

        /*
        private void Awake()
        {
            //_camera = GetComponent<Camera>();
            //_inputManager = InputManagerSingleton.Instance;
            //_inputManager.Player.MustLook.started += (_ => _mustLook = true);
            //_inputManager.Player.MustLook.canceled += (_ => _mustLook = false);
        }*/

        // Update is called once per frame
        private void FixedUpdate()
        {
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -10));
/*
            if (_mustLook)
            {
                Vector2 _lookTarget = _camera.ScreenToWorldPoint(_inputManager.Player.Look.ReadValue<Vector2>());

                Vector2 distance = _lookTarget - (Vector2)target.position;

                if (distance.magnitude > _maxRange)
                {
                    _lookTarget = (Vector2)targetPosition + distance.normalized * _maxRange;
                }

                transform.position = Vector3.SmoothDamp(transform.position,
                    pointBetween(targetPosition, _lookTarget), ref velocity,
                    _smoothTime);
            }
            else*/
            {
                transform.position = Vector3.SmoothDamp(transform.position,
                    targetPosition, ref velocity,
                    _smoothTime);
            }
        }

/*
        private Vector3 pointBetween(Vector3 a, Vector3 b)
        {
            return (a + b) / 2;
        }
        */
    }
}