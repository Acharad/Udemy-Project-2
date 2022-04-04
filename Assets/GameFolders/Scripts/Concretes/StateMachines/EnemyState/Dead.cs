using UdemyProject.Abstracts.Animations;
using UdemyProject.Abstracts.Controllers;
using UdemyProject.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject.StateMachines.EnemyState
{
    public class Dead : IState
    {
        private IEntityController _controller;
        private IMyAnimation _animation;

        private System.Action _deadCallback;

        private float _currentTime = 0f;

        public Dead(IEntityController controller, IMyAnimation animation, System.Action deadCallback)
        {
            _controller = controller;
            _animation = animation;
            _deadCallback = deadCallback;
        }
        
        public void OnEnter()
        {
            _animation.DeadAnimation();
            Debug.Log("Dead on enter");
            _deadCallback?.Invoke();
        }

        public void OnExit()
        {
            //We may need this if we want to use object pooling
            _currentTime = 0f;
            Debug.Log("Dead on exit");
        }

        public void Tick()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > 0.5f)
            {
                Object.Destroy(_controller.transform.gameObject);
            }
        }
    }
}
