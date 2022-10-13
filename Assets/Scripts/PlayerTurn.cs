using System.Collections;
using UnityEngine;

namespace Default
{
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

            //instantiate a card and add it to the list
            BattleSystem.spawnedObj = BattleSystem.Instantiate(BattleSystem.prefab);
            BattleSystem.cards.Add(BattleSystem.spawnedObj);

            yield break;
        }

        public override IEnumerator Remove()
        {
            //remove most recent object from list
            if (BattleSystem.cards.Count > 0)
            {
                BattleSystem.Destroy(BattleSystem.cards[BattleSystem.cards.Count - 1]);
                BattleSystem.cards.Remove(BattleSystem.cards[BattleSystem.cards.Count - 1]);
            }

            yield break;
        }
        public override IEnumerator Resolve()
        {
            //advance to resolution step
            BattleSystem.SetState(new Resolution(BattleSystem));

            yield break;
        }
    }
}
