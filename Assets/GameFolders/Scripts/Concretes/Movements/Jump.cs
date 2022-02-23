using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Movements;
using UnityEngine;

namespace UdemyProject.Movements
{
    public class Jump : IJump
    {
        Rigidbody2D _rigidBody;
        IOnGround _onGround;

        float _jumpForce = 350f;

        public bool IsJump { get; set; }

        public Jump (Rigidbody2D rigidbody2D, IOnGround onGround)
        {
            _rigidBody = rigidbody2D;
            _onGround = onGround;
        }

        public void TickWithFixedUpdate()
        {
            if(IsJump && _onGround.IsGround)
            {
                _rigidBody.velocity = Vector2.zero;
                _rigidBody.AddForce(Vector2.up * _jumpForce);
                _rigidBody.velocity = Vector2.zero;    

                IsJump = false;
            }
        }

    }    
}
