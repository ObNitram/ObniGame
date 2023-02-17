using System;
using Main.Character.LookModule.DirectionLook;
using UnityEngine;

namespace Main.Character.Module.LookModule.DirectionLook
{
    public class LookByRpgMakerAnim : AVector2
    {
        [SerializeField] private RpgMakerAnim _rpgMakerAnim;
        private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _scaleWalk = 0.1f;
        [SerializeField] private float _timeBetweenSprite = 0.1f;
        [SerializeField] private float _scaleIdle = 0.1f;
        [SerializeField] private float _scaleIdleSpeed = 0.1f;
        
        [SerializeField] private AVector2 directMove;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }


        Vector2 _lookDirection;


        public override void SetVector2(Vector2 direction)
        {
            _lookDirection = direction;
        }

        public override Vector2 GetVector2()
        {
            return _lookDirection;
        }


        private void LateUpdate()
        {
            SkinChoice();
        }

        private float _time;
        private int _animIndex = -1;
        private bool _idleScale = true;

        void SkinChoice()
        {
            int _animDirection;

            if (_lookDirection.y > Math.Abs(_lookDirection.x)) //up
            {
                _animDirection = 10;
            }
            else if (_lookDirection.x > Math.Abs(_lookDirection.y)) //right
            {
                _animDirection = 7;
            }
            else if (-_lookDirection.x > Math.Abs(_lookDirection.y)) //left
            {
                _animDirection = 4;
            }
            else /*if (-_lookDirection.y > Math.Abs(_lookDirection.x))*/ //down
            {
                _animDirection = 1;
            }


            if (directMove.GetVector2().magnitude < 0.5f) //idle
            {
                _time += Time.deltaTime;
                if (_time > _scaleIdleSpeed)
                {
                    _time = 0;
                    _idleScale = !_idleScale;
                }

                transform.localScale = _idleScale
                    ? new Vector3(1, 1 + _time * _scaleIdle, 1)
                    : new Vector3(1, 1 + (_scaleIdleSpeed - _time) * _scaleIdle, 1);

                _spriteRenderer.sprite = _rpgMakerAnim.sprites[_animDirection]; 
                return;
            }

            _time += Time.deltaTime;
            if (_time > _timeBetweenSprite)
            {
                _time = 0;
                _animIndex++;
                if (_animIndex > 2) _animIndex = -1;
            }

            transform.localScale = Math.Abs(_animIndex) == 1
                ? new Vector3(1, 1 + _time * _scaleWalk, 1)
                : new Vector3(1, 1 + (_timeBetweenSprite - _time) * _scaleWalk, 1);
            _spriteRenderer.sprite = _rpgMakerAnim.sprites[_animDirection + (_animIndex == 2 ? 0 : _animIndex)];
        }
    }
}