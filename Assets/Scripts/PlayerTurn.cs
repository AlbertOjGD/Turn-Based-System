using System.Collections;
using UnityEngine;

 public class PlayerTurn : State
    {
        public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            Debug.Log("State Machine - Player Turn");

            //draw card (1)

            //set mana to maximum mana minus upkeep costs

            yield break;
        }

        public override IEnumerator Attack()
        {

            yield break;
        }

        public override IEnumerator Remove()
        {

            yield break;
        }
        public override IEnumerator Resolve()
        {
            //advance to resolution step
            BattleSystem.SetState(new Resolution(BattleSystem));

            yield break;
        }
    }

