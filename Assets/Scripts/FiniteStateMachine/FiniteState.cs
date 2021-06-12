using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;

namespace Pintos.FiniteStateMachine
{
    public abstract class FiniteState
    {
        protected FiniteController controller;
        protected StateMachine stateMachine;

        protected float startTime;

        protected string animBoolName;

        public FiniteState(string animBoolName, FiniteController controller, StateMachine stateMachine)
        {
            this.controller = controller;
            this.stateMachine = stateMachine;
            this.animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            DoChecks();
            controller.Anim.SetBool(animBoolName, true);
            startTime = Time.time;
        }

        public virtual void Exit()
        {
            controller.Anim.SetBool(animBoolName, false);
        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {

        }
        

    }
}