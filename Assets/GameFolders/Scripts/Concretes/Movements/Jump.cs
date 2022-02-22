using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject.Movements
{
    public class Jump
    {
        Rigidbody2D _rigidBody;

        float _jumpForce = 350f;

        public Jump (Rigidbody2D rigidbody2D)
        {
            _rigidBody = rigidbody2D;
        }

        public void TickWithFixedUpdate()
        {
            _rigidBody.velocity = Vector2.zero;

            _rigidBody.AddForce(Vector2.up * _jumpForce);

            _rigidBody.velocity = Vector2.zero;
        }

    }    
}
