using UdemyProject.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject.StateMachines.EnemyState
{
    public class Attack : IState
    {
        public void OnEnter()
        {
            
            Debug.Log("Attack on enter");
        }

        public void OnExit()
        {
            Debug.Log("Attack on exit");
        }

        public void Tick()
        {
            Debug.Log("Attack tick");
        }
    }
}

