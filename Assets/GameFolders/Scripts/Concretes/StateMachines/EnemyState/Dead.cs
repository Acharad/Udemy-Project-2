using UdemyProject.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject.StateMachines.EnemyState
{
    public class Dead : IState
    {
        void IState.OnEnter()
        {
            Debug.Log("Dead on enter");
        }

        void IState.OnExit()
        {
            Debug.Log("Dead on exit");
        }

        void IState.Tick()
        {
            Debug.Log("Dead tick");
        }
    }
}
