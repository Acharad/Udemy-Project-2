using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Inputs;
using UdemyProject.Abstracts.Movements;
using UdemyProject.Abstracts.Animations;
using UdemyProject.Abstracts.Controllers;
using UdemyProject.Inputs;
using UdemyProject.Movements;
using UdemyProject.Animations;
using UnityEngine;

namespace UdemyProject.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float moveSpeed = 3f;
        
        IPlayerInput _input;
        IMover _mover;
        IMyAnimation _animation;
        IFlip _flip;
        

        IJump _jump;
        IOnGround _iOnGround;

        float _horizontal;
        // bool _isJump = false;
        // bool _isAttack = false;

        private void Awake()
        {
            _input = new PcInput();
            _mover = new Mover(this, moveSpeed);
            _animation = new PlayerAnimation(GetComponent<Animator>());
            _flip = new FlipWithTransform(this);
            _iOnGround = GetComponent<IOnGround>();
            _jump = new JumpMultiple(GetComponent<Rigidbody2D>(), _iOnGround);
        }

        private void Update()
        {
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