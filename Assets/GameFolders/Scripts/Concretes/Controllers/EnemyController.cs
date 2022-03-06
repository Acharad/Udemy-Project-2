using System.Collections;
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
        
        private StateMachine _stateMachine;
        private IEntityController _player;
        
        private void Awake()
        {
            _stateMachine = new StateMachine();
            _player = FindObjectOfType<PlayerController>();
        }

        private IEnumerator Start()
        {
            IMover mover = new Mover(this, moveSpeed);
            IMyAnimation myAnimation = new PlayerAnimation(GetComponent<Animator>());
            IFlip flip = new FlipWithTransform(this);
            
            IHealth health = GetComponent<IHealth>();
            IAttacker attacker = GetComponent<IAttacker>();
            IStopEdge stopEdge = GetComponent<IStopEdge>();
            
            Idle idle = new Idle(mover, myAnimation);
            Walk walk = new Walk(this, mover, myAnimation, flip, patrols);
            ChasePlayer chasePlayer = new ChasePlayer(mover, flip, myAnimation, stopEdge, IsPlayerRightSide);
            Attack attack = new Attack(_player.transform.GetComponent<IHealth>(), flip, myAnimation, attacker, attackDelay, IsPlayerRightSide);
            TakeHit takeHit = new TakeHit(health, myAnimation);
            Dead dead = new Dead(this, myAnimation);
            
            _stateMachine.AddTransition(idle, walk, () => !idle.IsIdle );
            _stateMachine.AddTransition(idle, chasePlayer, () => DistanceFromMeToPlayer() < chaseDistance);
            _stateMachine.AddTransition(walk, chasePlayer, () => DistanceFromMeToPlayer() < chaseDistance);
            _stateMachine.AddTransition(chasePlayer, attack, () => DistanceFromMeToPlayer() < attackDistance);
            
            _stateMachine.AddTransition(walk, idle, () => !walk.IsWalking);
            _stateMachine.AddTransition(chasePlayer, idle, () => DistanceFromMeToPlayer() > chaseDistance);
            _stateMachine.AddTransition(attack, chasePlayer, () => DistanceFromMeToPlayer() > attackDistance);
            
            _stateMachine.AddAnyState(takeHit, () => takeHit.IsTakeHit);
            _stateMachine.AddAnyState(dead, () => health.IsDead);
            
            _stateMachine.AddTransition(takeHit, chasePlayer, () => !takeHit.IsTakeHit);

            _stateMachine.SetState(idle);

            yield return null;
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

        private bool IsPlayerRightSide()
        {
            Vector3 result = _player.transform.position - this.transform.position;

            if (result.x > 0f)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
