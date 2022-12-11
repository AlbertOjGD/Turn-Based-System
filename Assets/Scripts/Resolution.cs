using System;
using System.Collections;
using UnityEngine;

public class Resolution : State
    {
    public Resolution(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator Start()
    {
        BattleSystem.paused = true;
        Debug.Log("State Machine - Resolution");
        for (int i = 0; i < BattleSystem.gm.resolutionOrder.Count; i++)
        {
            if (BattleSystem.gm.resolutionOrder[i].GetComponent<GridCell>().myCard != null)
            {
                BattleSystem.gm.resolutionOrder[i].GetComponent<GridCell>().myCard.GetComponent<DraggableObject>().PlayCard();
                yield return new WaitForSeconds(0.5f);
            }
        }

        BattleSystem.paused = false;
        BattleSystem.SetState(new PlayerTurn(BattleSystem));
        
        yield break;
        }
    }