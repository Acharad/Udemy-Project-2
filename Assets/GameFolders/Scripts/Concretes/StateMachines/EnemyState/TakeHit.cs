using UdemyProject.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject.StateMachines.EnemyState
{
    public class TakeHit : IState
    {
        void IState.OnEnter()
        {
            Debug.Log("TakeHit on enter");
        }

        void IState.OnExit()
        {
            Debug.Log("TakeHit on exit");
        }

        void IState.Tick()
        {
            Debug.Log("TakeHit tick");
        }
    }
}
