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

        private float _currentTime = 0f;

        public Dead(IEntityController controller, IMyAnimation animation)
        {
            _controller = controller;
            _animation = animation;
        }
        
        public void OnEnter()
        {
            _animation.DeadAnimation();
            Debug.Log("Dead on enter");
        }

        public void OnExit()
        {
            //We may need this if we want to use object pooling
            _currentTime = 0f;
            Debug.Log("Dead on exit");
        }

        public void Tick()
        {
            if (_currentTime > 3f)
            {
                Object.Destroy(_controller.transform.gameObject);
                CapsuleCollider2D capsuleCollider2D =
                    _controller.transform.gameObject.GetComponent<CapsuleCollider2D>();
                capsuleCollider2D.enabled = false;
            }
                
            
            Debug.Log("Dead tick");
        }
    }
}
