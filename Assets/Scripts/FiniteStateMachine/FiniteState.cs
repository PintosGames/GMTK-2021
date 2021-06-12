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
        protected FiniteStateMachine stateMachine;
        protected ScriptableObject data;

        protected float startTime;

        protected string animBoolName;

        public FiniteState(FiniteController controller, FiniteStateMachine stateMachine, ScriptableObject data, string animBoolName)
        {
            this.controller = controller;
            this.stateMachine = stateMachine;
            this.data = data;
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