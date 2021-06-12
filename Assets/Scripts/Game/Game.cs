using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pintos.FiniteStateMachine;
using Pintos.Game.States;

namespace Pintos.Game
{
    public class Game : FiniteController
    {
        public GameData data;

        public FoodOnlyState FoodOnlyState { get; private set; }

        public override void Initialize()
        {
            FoodOnlyState = new FoodOnlyState(null, this, StateMachine, data);

            startState = FoodOnlyState;
        }

        public override void LogicUpdate()
        {

        }
    }
}
