using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProwlState : ScrapWolfSetter
{
    NavMeshAgent wolfAgent;

    public override void EnterState(ScrapWolfManager state)
    {
        state.searchingHitBox.enabled = true;
        state.searchingHitBox.isTrigger = true;
        state.searchingForTarget = true;

        state.isGoingToShip= true;

        state.defenseGolemTargets.Clear();
    }

    public override void RunCurrentState(ScrapWolfManager state)
    {
        wolfAgent = state.scrapWolfAgent;
        wolfAgent.speed = 2.1f;
        wolfAgent.destination = state.shipToDestroy.transform.position;
    }
}
