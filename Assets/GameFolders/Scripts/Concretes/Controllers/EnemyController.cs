using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.Animations;
using UdemyProject.Abstracts.Combats;
using UdemyProject.Abstracts.Controllers;
using UdemyProject.Abstracts.Movements;
using UdemyProject.Animations;
using UdemyProject.Movements;
using UdemyProject.StateMachines;
using UdemyProject.StateMachines.EnemyState;
using UnityEngine;

namespace  UdemyProject.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [Header("Movements")]
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private Transform[] patrols;
        
        [Header("Attacks")]
        [SerializeField] private float chaseDistance = 3f;
        [SerializeField] private float attackDistance = 1f;
        [SerializeField] private float attackDelay = 1f;
        
        
        
        // [SerializeField] private bool isWalk = false;
        // [SerializeField] private bool isTakeHit = false;

        
        
        
        private IMover _mover;
        private IMyAnimation _animation;
        private IFlip _flip;
        private StateMachine _stateMachine;
        private IEntityController _player;
        private IHealth _health;
        private IAttacker _attacker;
        private void Awake()
        {
            _mover = new Mover(this, moveSpeed);
            _animation = new PlayerAnimation(GetComponent<Animator>());
            _flip = new FlipWithTransform(this);
            _stateMachine = new StateMachine();
            _health = GetComponent<IHealth>();
            _attacker = GetComponent<IAttacker>();
            _player = FindObjectOfType<PlayerController>();
        }

        private void Start()
        {
            Idle idle = new Idle(_mover, _animation);
            Walk walk = new Walk(this, _mover, _animation, _flip, patrols);
            ChasePlayer chasePlayer = new ChasePlayer(this, _player, _mover, _flip, _animation);
            Attack attack = new Attack(this, _player, _flip, _animation, _attacker, attackDelay);
            TakeHit takeHit = new TakeHit(_health, _animation);
            Dead dead = new Dead(this, _animation);
            
            _stateMachine.AddTransition(idle, walk, () => !idle.IsIdle );
            _stateMachine.AddTransition(idle, chasePlayer, () => DistanceFromMeToPlayer() < chaseDistance);
            _stateMachine.AddTransition(walk, chasePlayer, () => DistanceFromMeToPlayer() < chaseDistance);
            _stateMachine.AddTransition(chasePlayer, attack, () => DistanceFromMeToPlayer() < attackDistance);
            
            _stateMachine.AddTransition(walk, idle, () => !walk.IsWalking);
            _stateMachine.AddTransition(chasePlayer, idle, () => DistanceFromMeToPlayer() > chaseDistance);
            _stateMachine.AddTransition(attack, chasePlayer, () => DistanceFromMeToPlayer() > attackDistance);
            
            _stateMachine.AddAnyState(takeHit, () => takeHit.IsTakeHit);
            _stateMachine.AddAnyState(dead, () => _health.IsDead);
            
            _stateMachine.AddTransition(takeHit, chasePlayer, () => !takeHit.IsTakeHit);

            _stateMachine.SetState(idle);
        }

        private void Update()
        {
            _stateMachine.Tick();
        }

        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
            // Gizmos.DrawWireSphere(transform.position, attackDistance);
        }
        
        private float DistanceFromMeToPlayer()
        {
            return Vector2.Distance(transform.position, _player.transform.position);
        }
    }
}
