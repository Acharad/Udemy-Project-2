using System.Collections;
using System.Collections.Generic;
using UdemyProject.Controllers;
using UdemyProject.Abstracts.Animations;
using UnityEngine;

namespace UdemyProject.Animations
{
    public class PlayerAnimation : IMyAnimation
    {
        Animator _animator;

        public PlayerAnimation(Animator animator)
        {
            _animator = animator;
        }

        public void MoveAnimation(float moveSpeed)
        {
            _animator.SetFloat("moveSpeed", Mathf.Abs(moveSpeed));
        }
    }    
}
