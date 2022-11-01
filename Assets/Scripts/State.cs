using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class State
    {
        protected BattleSystem BattleSystem;

        public State(BattleSystem battleSystem)
        {
            BattleSystem = battleSystem;
        }

        //run on initialization of the state
        public virtual IEnumerator Start()
        {
            yield break;
        }

        //run on button press to add attack
        public virtual IEnumerator Attack()
        {
            yield break;
        }

        //run on button press to remove attack
        public virtual IEnumerator Remove()
        {
            yield break;
        }

        //run on button press to advance turn
        public virtual IEnumerator Resolve()
        {
            yield break;
        }
    }
