using UdemyProject.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject.StateMachines.EnemyState
{
    public class ChasePlayer : IState
    {
        void IState.OnEnter()
        {
            Debug.Log("ChasePlayer on enter");
        }

        void IState.OnExit()
        {
            Debug.Log("ChasePlayer on exit");
        }

        void IState.Tick()
        {
            Debug.Log("ChasePlayer on tick");
        }
    }
}

