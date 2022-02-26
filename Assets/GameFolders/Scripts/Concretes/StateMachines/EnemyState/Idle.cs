using UdemyProject.Abstracts.Animations;
using UdemyProject.Abstracts.Movements;
using UdemyProject.Abstracts.StateMachines;
using UnityEngine;


namespace UdemyProject.StateMachines.EnemyState
{
    public class Idle : IState
    {
        private IMover _mover;
        private IMyAnimation _animation;

        private float _maxStandTime;
        private float _currentStandTime = 0f;

        public bool IsIdle { get; private set; }
        
        //ctor method
        public Idle(IMover mover,IMyAnimation animation)
        {
            _mover = mover;
            _animation = animation;
        }
        void IState.OnEnter()
        {
            IsIdle = true;
            _animation.MoveAnimation(0f);
            Debug.Log("Idle on enter");

            _maxStandTime = Random.Range(4f, 10f);
        }

        void IState.OnExit()
        {
            _currentStandTime = 0f;
            Debug.Log("Idle on exit");
        }

        void IState.Tick()
        {
            _mover.Tick(0f);

            _currentStandTime += Time.deltaTime;

            if (_currentStandTime > _maxStandTime)
                IsIdle = false;
            
            Debug.Log("Idle tick");
        }
    }
}
