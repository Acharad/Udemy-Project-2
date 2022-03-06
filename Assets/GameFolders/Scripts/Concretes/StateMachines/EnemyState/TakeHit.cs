using UdemyProject.Abstracts.Animations;
using UdemyProject.Abstracts.Combats;
using UdemyProject.Abstracts.StateMachines;
using UnityEditor;
using UnityEngine;

namespace UdemyProject.StateMachines.EnemyState
{
    public class TakeHit : IState
    {
        private IHealth _health;
        private IMyAnimation _animation;

        private float _maxDelayTime = 0.3f;
        private float _currentDelayTime;

        public bool IsTakeHit { get; private set; }

        public TakeHit(IHealth health, IMyAnimation animation)
        {
            health.OnHealthChanged += OnEnter;
            _animation = animation;
        }
        public void OnEnter()
        {
            IsTakeHit = true;
            _animation.TakeHitAnimation();
            Debug.Log("TakeHit on enter");
        }

        public void OnExit()
        {
            _currentDelayTime = 0f;
            Debug.Log("TakeHit on exit");
        }

        public void Tick()
        {
            _currentDelayTime += Time.deltaTime;
            if (_currentDelayTime > _maxDelayTime && IsTakeHit)
            {
                
                IsTakeHit = false;
            }
        }
    }
}
