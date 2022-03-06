using System.Numerics;
using UdemyProject.Abstracts.Animations;
using UdemyProject.Abstracts.Controllers;
using UdemyProject.Abstracts.Movements;
using UdemyProject.Abstracts.StateMachines;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace UdemyProject.StateMachines.EnemyState
{
    public class Walk : IState
    {
        private IMover _mover;
        private IMyAnimation _animation;
        private IFlip _flip;
        private IEntityController _entityController;

        private int _patrolIndex = 0;
        private float _direction;
        
        private Transform[] _patrols;
        private Transform _currentPatrol;

        public bool IsWalking { get; private set; }

        public Walk(IEntityController entityController,IMover mover, IMyAnimation animation, IFlip flip, params Transform[] patrols)
        {
            _mover = mover;
            _animation = animation;
            _flip = flip;
            // _moveSpeed = moveSpeed;
            _patrols = patrols;
            _entityController = entityController;
        }
        
        public void OnEnter()
        {
            if (_patrols.Length < 1) return;
            
            _currentPatrol = _patrols[_patrolIndex];

            Vector3 leftOrRight = _currentPatrol.position - _entityController.transform.position;
            _flip.FlipCharacter(leftOrRight.x > 0f ? 1f : -1f);
            
            _direction = _entityController.transform.localScale.x;
            
            _animation.MoveAnimation(1f);
            IsWalking = true;
            Debug.Log(_currentPatrol);
            Debug.Log("Walk on enter");
        }

        public void OnExit()
        {
            _direction *= -1;
            // _flip.FlipCharacter(_direction);
            _animation.MoveAnimation(0f);
            IsWalking = false;
            

            _patrolIndex++;
            
            if (_patrolIndex >= _patrols.Length)
                _patrolIndex = 0;
            
            Debug.Log(_currentPatrol);
            Debug.Log("Walk on exit");
        }

        public void Tick()
        {
            if (_currentPatrol == null) return;

            Vector2 enemyPosition = _entityController.transform.position;
            enemyPosition.y = 0f;
            Vector2 currentPosition = _currentPatrol.position;
            currentPosition.y = 0f;

            if (Vector2.Distance(enemyPosition, currentPosition) <= 0.2f)
            {
                IsWalking = false;
                return;
            }
            _mover.Tick(_direction);
        }
    }
}

