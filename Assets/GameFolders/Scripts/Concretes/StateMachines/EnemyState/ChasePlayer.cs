using UdemyProject.Abstracts.Animations;
using UdemyProject.Abstracts.Controllers;
using UdemyProject.Abstracts.Movements;
using UdemyProject.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject.StateMachines.EnemyState
{
    public class ChasePlayer : IState
    {
        private IEntityController _enemy, _player;
        private IMover _mover;
        private IFlip _flip;
        private IMyAnimation _animation;

        public ChasePlayer(IEntityController enemy, IEntityController player, IMover mover, IFlip flip, IMyAnimation animation)
        {
            _enemy = enemy;
            _player = player;
            _mover = mover;
            _flip = flip;
            _animation = animation;
        }
        public void OnEnter()
        {
            _animation.MoveAnimation(1f);
            Debug.Log("ChasePlayer on enter");
        }

        public void OnExit()
        {
            _animation.MoveAnimation(0f);   
            Debug.Log("ChasePlayer on exit");
        }

        public void Tick()
        {
            Vector3 leftOrRight = _player.transform.position - _enemy.transform.position;

            if (leftOrRight.x > 0)
            {
                _mover.Tick(1.5f);
                _flip.FlipCharacter(1f);
            }
            else
            {
                _mover.Tick(-1.5f);
                _flip.FlipCharacter(-1f);
            }
                
            Debug.Log("ChasePlayer on tick");
        }
    }
}

