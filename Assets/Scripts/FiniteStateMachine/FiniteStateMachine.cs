using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pintos.FiniteStateMachine
{
    public class StateMachine
    {
        public FiniteState CurrentState { get; private set; }

        public void Initialize(FiniteState startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(FiniteState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}