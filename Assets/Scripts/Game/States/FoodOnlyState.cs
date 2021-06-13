using System.Collections;
using System.Collections.Generic;
using Pintos.FiniteStateMachine;
using UnityEngine;

using Pintos.Game.Objects;

namespace Pintos.Game.States
{
    public class FoodOnlyState : GameState
    {
        public FoodOnlyState(string animBoolName, FiniteController controller, StateMachine stateMachine, GameData data) : base(animBoolName, controller, stateMachine, data)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            data.Spawn(data.foodPrefab);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!MonoBehaviour.FindObjectOfType<Food>())
                data.Spawn(data.foodPrefab);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}