using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Inputs;
using UdemyProject.Abstracts.Movements;
using UdemyProject.Abstracts.Animations;
using UdemyProject.Abstracts.Combats;
using UdemyProject.Abstracts.Controllers;
using UdemyProject.Inputs;
using UdemyProject.Movements;
using UdemyProject.Animations;
using UdemyProject.Uis;
using UnityEngine;

namespace UdemyProject.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float moveSpeed = 3f;
        
        private IPlayerInput _input;
        private IMover _mover;
        private IMyAnimation _animation;
        private IFlip _flip;
        private IJump _jump;
        private IOnGround _iOnGround;
        private IHealth _health;

        private float _horizontal;

        private void Awake()
        {
            _input = new PcInput();
            _mover = new Mover(this, moveSpeed);
            _animation = new PlayerAnimation(GetComponent<Animator>());
            _flip = new FlipWithTransform(this);
            _iOnGround = GetComponent<IOnGround>();
            _jump = new JumpMultiple(GetComponent<Rigidbody2D>(), _iOnGround);
            _health = GetComponent<IHealth>();
        }

        private void Start()
        {
            var gameOverObject = FindObjectOfType<GameOverObject>();
            gameOverObject.SetPlayerHealth(_health);
        }

        private void Update()
        {
            if (_health.IsDead) return;
            
            _horizontal = _input.Horizontal;

            if(_input.AttackButtonDown)
            {
                Debug.Log("attack clicked");
                _animation.AttackAnimation();
                return;
            }
            
            if(_input.JumpButtonDown)
            {
                _jump.IsJump = true;
            }

            _animation.JumpAnimation(!_iOnGround.IsGround);
            _animation.MoveAnimation(_horizontal);
        }

        private void FixedUpdate()
        {
            _flip.FlipCharacter(_horizontal);
            _mover.Tick(_horizontal);

            _jump.TickWithFixedUpdate();
        }
    }
}