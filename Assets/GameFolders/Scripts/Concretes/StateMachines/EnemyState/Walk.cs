using UdemyProject.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject.StateMachines.EnemyState
{
    public class Walk : IState
    {
        void IState.OnEnter()
        {
            Debug.Log("Walk on enter");
        }

        void IState.OnExit()
        {
            Debug.Log("Walk on exit");
        }

        void IState.Tick()
        {
            Debug.Log("Walk tick");
        }
    }
}

