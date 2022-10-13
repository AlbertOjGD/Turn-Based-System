using System;
using System.Collections.Generic;
using UnityEngine;

namespace Default
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State State;

        public void SetState(State state)
        {
            State = state;
            StartCoroutine(State.Start());
        }
    }
}
