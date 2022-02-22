using System.Collections;
using System.Collections.Generic;
using UdemyProject.Controllers;
using UdemyProject.Abstracts.Movements;
using UnityEngine;

namespace UdemyProject.Movements
{
    public class FlipWithTransform : IFlip
    {
        PlayerController _player;

        public FlipWithTransform(PlayerController player)
        {
            _player = player;
        }

        public void FlipCharacter(float direction)
        {
            if (direction == 0f) return;

            float mathValue = Mathf.Sign(direction);

            if(mathValue != _player.transform.localScale.x)
            {
                _player.transform.localScale = new Vector2(mathValue, 1f);
            }
        }
    }
}