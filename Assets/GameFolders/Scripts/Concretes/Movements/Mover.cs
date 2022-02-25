using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Controllers;
using UdemyProject.Abstracts.Movements;
using UdemyProject.Controllers;
using UnityEngine;

namespace UdemyProject.Movements
{
    public class Mover : IMover
    {
        IEntityController _controller;
        // float moveSpeed = 3f;
        private float _moveSpeed;

        public Mover(IEntityController controller, float moveSpeed)
        {
            _controller = controller;
            _moveSpeed = moveSpeed;
        }

        public void Tick(float horizontal)
        {
            if(horizontal == 0f) return;

            _controller.transform.Translate(Vector2.right * horizontal * Time.deltaTime * _moveSpeed);
        }
    }    
}
