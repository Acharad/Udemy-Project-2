using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Animations;
using UdemyProject.Abstracts.Controllers;
using UdemyProject.Abstracts.Movements;
using UdemyProject.Animations;
using UdemyProject.Movements;
using UnityEngine;

namespace  UdemyProject.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float moveSpeed = 2f;
        
        private IMover _mover;
        private IMyAnimation _animation;
        private IFlip _flip;
        private IOnGround _onGround;
        

        private void Awake()
        {
            _mover = new Mover(this, moveSpeed);
            _animation = new PlayerAnimation(GetComponent<Animator>());
            _flip = new FlipWithTransform(this);
            _onGround = GetComponent<IOnGround>();
        }
        
    }
}
