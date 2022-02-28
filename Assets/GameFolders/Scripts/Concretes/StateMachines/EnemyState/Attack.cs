using UdemyProject.Abstracts.Animations;
using UdemyProject.Abstracts.Combats;
using UdemyProject.Abstracts.Controllers;
using UdemyProject.Abstracts.Movements;
using UdemyProject.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject.StateMachines.EnemyState
{
    public class Attack : IState
    {
        private IEntityController _enemyController;
        private IEntityController _playerController;
        private IFlip _flip;
        private IMyAnimation _animation;
        private IAttacker _attacker;
        private IHealth _playerHealth;

        private float _currentAttackDelayTime;
        private float _maxAttackDelayTime;

        // private int _firstAttack = 0;

        public Attack(IEntityController enemyController, IEntityController playerController, IFlip flip, 
            IMyAnimation animation, IAttacker attacker, float maxAttackDelayTime)
        {
            _enemyController = enemyController;
            _playerController = playerController;
            _flip = flip;
            _animation = animation;
            _attacker = attacker;
            _playerHealth = _playerController.transform.GetComponent<IHealth>();
            _maxAttackDelayTime = maxAttackDelayTime;
        }
        
        public void OnEnter()
        {
            _currentAttackDelayTime = 0f;
            Debug.Log("Attack on enter");
        }

        public void OnExit()
        {
            Debug.Log("Attack on exit");
        }

        public void Tick()
        {
            _currentAttackDelayTime += Time.deltaTime;
            if (_currentAttackDelayTime > _maxAttackDelayTime)
            {
                _animation.AttackAnimation();
                _attacker.Attack(_playerHealth);
                _currentAttackDelayTime = 0f;
            }
            Debug.Log("Attack tick");
        }
    }
}

