using System.Collections;
using System.Collections.Generic;
using Pintos.FiniteStateMachine;
using UnityEngine;

namespace Pintos.Player
{
    public class MovingState : PlayerState
    {
        public MovingState(FiniteController controller, FiniteStateMachine.FiniteStateMachine stateMachine, ScriptableObject data, string animBoolName) : base(controller, stateMachine, data, animBoolName)
        {
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
