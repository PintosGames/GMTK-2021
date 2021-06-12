using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pintos.FiniteStateMachine;
using Pintos.Player.States;

namespace Pintos.Player
{
    public class Player : FiniteController
    {
        public PlayerData Data;

        public List<Transform> body;
        public MovingState MovingState { get; private set; }

        public override void Initialize()
        {
            MovingState = new MovingState("moving", this, StateMachine, Data);

            startState = MovingState;
        }

        public override void LogicUpdate()
        {

        }
    }
}
