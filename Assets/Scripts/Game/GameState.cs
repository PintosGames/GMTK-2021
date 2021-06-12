using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pintos.FiniteStateMachine;

namespace Pintos.Game
{
    public class GameState : FiniteState
    {
        protected GameData data;

        public GameState(string animBoolName, FiniteController controller, StateMachine stateMachine, GameData data) : base(animBoolName, controller, stateMachine)
        {
            this.data = data;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
