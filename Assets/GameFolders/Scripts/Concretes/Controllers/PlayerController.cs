using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Inputs;
using UdemyProject.Abstracts.Movements;
using UdemyProject.Abstracts.Animations;
using UdemyProject.Inputs;
using UdemyProject.Movements;
using UdemyProject.Animations;
using UnityEngine;

namespace UdemyProject.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        IPlayerInput _input;
        IMover _mover;
        IMyAnimation _animation;
        IFlip _flip;

        Jump _jump;
        IOnGround _iOnGround;

        float _horizontal;
        bool _isJump = false;

        private void Awake()
        {
            _input = new PcInput();
            _mover = new Mover(this);
            _animation = new PlayerAnimation(GetComponent<Animator>());
            _flip = new FlipWithTransform(this);
            _jump = new Jump(GetComponent<Rigidbody2D>());
            _iOnGround = GetComponent<IOnGround>();
        }

        private void Update()
        {
            _horizontal = _input.Horizontal;
            
            if(_input.JumpButtonDown && _iOnGround.IsGround)
            {
                _isJump = true;
            }

            _animation.JumpAnimation(!_iOnGround.IsGround);
            _animation.MoveAnimation(_horizontal);
        }

        private void FixedUpdate()
        {
            _flip.FlipCharacter(_horizontal);
            _mover.Tick(_horizontal);

            if(_isJump)
            {
                _jump.TickWithFixedUpdate();
                _isJump = false;
            }
        }
    }
}