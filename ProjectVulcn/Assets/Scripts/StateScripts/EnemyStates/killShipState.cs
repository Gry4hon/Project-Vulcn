using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killShipState : ScrapWolfSetter
{
    ScrapWolfManager theStateManager;
    public override void EnterState(ScrapWolfManager state)
    {
        state.scrapWolfAgent.destination = state.scrapWolf.transform.position;

        theStateManager = state;
        state.StartCoroutine(DamageShip());
    }

    public override void RunCurrentState(ScrapWolfManager state)
    {

    }


    IEnumerator DamageShip()
    {
        while(true)
        {
            yield return new WaitForSeconds(4);
            theStateManager.gameMaster.DamageShip();
        }
    }
}

