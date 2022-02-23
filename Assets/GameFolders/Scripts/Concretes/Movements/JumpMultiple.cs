using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Movements;
using UnityEngine;

namespace UdemyProject.Movements
{
    public class JumpMultiple : IJump
    {
        Rigidbody2D _rigidBody;
        IOnGround _onGround;

        float _jumpForce = 350f;
        int _maxJumpCount = 2;
        int _currentJumpCount = 0;

        public bool IsJump { get; set; }

        public JumpMultiple (Rigidbody2D rigidbody2D, IOnGround onGround)
        {
            _rigidBody = rigidbody2D;
            _onGround = onGround;
        }

        public void TickWithFixedUpdate()
        {
            if (IsJump)
            {
                if(_currentJumpCount < _maxJumpCount)
                {
                    _rigidBody.velocity = Vector2.zero;
                    _rigidBody.AddForce(Vector2.up * _jumpForce);
                    _rigidBody.velocity = Vector2.zero;

                    _currentJumpCount++;
                    IsJump = false;
                    Debug.Log(_currentJumpCount);
                }
                else if(_onGround.IsGround)
                {
                    IsJump = false;
                    _currentJumpCount = 0;
                }
            }
        }
    }
}