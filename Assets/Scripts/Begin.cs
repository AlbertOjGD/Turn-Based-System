using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class Begin : State
    {
        public Begin(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            Debug.Log("State Machine - Start State");

            yield return new WaitForSeconds(0.5f);

            BattleSystem.SetState(new PlayerTurn(BattleSystem));
        }
    }

