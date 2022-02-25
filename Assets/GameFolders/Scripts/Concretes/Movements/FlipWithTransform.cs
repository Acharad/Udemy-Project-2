using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Controllers;
using UdemyProject.Controllers;
using UdemyProject.Abstracts.Movements;
using UnityEngine;

namespace UdemyProject.Movements
{
    public class FlipWithTransform : IFlip
    {
        IEntityController _controller;

        public FlipWithTransform(IEntityController controller)
        {
            _controller = controller;
        }

        public void FlipCharacter(float direction)
        {
            if (direction == 0f) return;

            float mathValue = Mathf.Sign(direction);

            if(mathValue != _controller.transform.localScale.x)
            {
                _controller.transform.localScale = new Vector2(mathValue, 1f);
            }
        }
    }
}