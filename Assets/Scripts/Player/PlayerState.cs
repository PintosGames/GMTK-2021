using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pintos.FiniteStateMachine;

namespace Pintos.Player
{
    public abstract class PlayerState : FiniteState
    {
        protected PlayerData data;

        protected PlayerState(string animBoolName, FiniteController controller, StateMachine stateMachine, PlayerData data) : base(animBoolName, controller, stateMachine)
        {
            this.data = data;
        }

        public override void DoChecks()
        {
            base.DoChecks();
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

