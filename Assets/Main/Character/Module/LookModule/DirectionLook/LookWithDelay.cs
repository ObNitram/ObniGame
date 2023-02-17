using UnityEngine;

namespace Main.Character.Module.LookModule.DirectionLook
{
    public class LookWithDelay: AVector2
    {
        [SerializeField] private float delay = 0.1f;
        [SerializeField] private AVector2 look;
        
        private Vector2 _targetLook;
        
        public override void SetVector2(Vector2 direction)
        {
            _targetLook = direction;
        }

        public override Vector2 GetVector2()
        {
            return look.GetVector2();
        }

        private Vector2 _velocity;
        private void Update()
        {
            if (_targetLook == Vector2.zero) return;
            look.SetVector2(Vector2.SmoothDamp(look.GetVector2(), _targetLook, ref _velocity, delay));
        }
    }
}