using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject.StateMachines
{
    public class StateMachine
    {
        List<StateTransition> _stateTransitions = new List<StateTransition>();

        IState _currentState; // Idle

        public void SetState(IState state) //Idle
        {
            // iki state de idle ise tekrardan statei set etmiyor.
            // state değişmişse (hit,death,attack) statei set ediyor.
            if(state == _currentState) return;

            _currentState?.OnExit();

            _currentState = state;

            _currentState.OnEnter();
        }

        public void Tick()
        {
            StateTransition stateTransition = CheckForTransition();

            if(stateTransition != null)
            {
                SetState(stateTransition.To);
            }

            _currentState.Tick();
        }

        private StateTransition CheckForTransition()
        {
            foreach(StateTransition stateTransition in _stateTransitions)
            {
                if(stateTransition.Condition() && stateTransition.From == _currentState)
                    return stateTransition;
            }

            return null;
        }

        public void AddTransition(IState from, IState to, System.Func<bool> condition)
        {
            StateTransition stateTransition = new StateTransition(from, to, condition);
            _stateTransitions.Add(stateTransition);
        }
    }    
}
