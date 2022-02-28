using UdemyProject.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject.StateMachines.EnemyState
{
    public class Dead : IState
    {
        public void OnEnter()
        {
            Debug.Log("Dead on enter");
        }

        public void OnExit()
        {
            Debug.Log("Dead on exit");
        }

        public void Tick()
        {
            Debug.Log("Dead tick");
        }
    }
}
