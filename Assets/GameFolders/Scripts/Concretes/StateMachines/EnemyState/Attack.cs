using UdemyProject.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject.StateMachines.EnemyState
{
    public class Attack : IState
    {
        void IState.OnEnter()
        {
            Debug.Log("Attack on enter");
        }

        void IState.OnExit()
        {
            Debug.Log("Attack on exit");
        }

        void IState.Tick()
        {
            Debug.Log("Attack tick");
        }
    }
}

