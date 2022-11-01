using System;
using System.Collections;
using UnityEngine;

    public class Resolution : State
    {

        public Resolution(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        private int arrayLength;

        public override IEnumerator Start()
        {
            Debug.Log("State Machine - Resolution");

            arrayLength = BattleSystem.cards.Count - 1;

            for (int i = 0; i - 1 < arrayLength; i++)
            {
                BattleSystem.Destroy(BattleSystem.cards[arrayLength - i]);
                BattleSystem.cards.Remove(BattleSystem.cards[arrayLength - i]);
                yield return new WaitForSeconds(0.5f);
            }

            BattleSystem.SetState(new PlayerTurn(BattleSystem));

            yield break;
        }
    }