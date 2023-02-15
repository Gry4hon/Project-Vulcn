using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProwlState : ScrapWolfSetter
{
    NavMeshAgent wolfAgent;
    

    public override void EnterState(ScrapWolfManager state)
    {

    }

    public override void RunCurrentState(ScrapWolfManager state)
    {
        wolfAgent = state.scrapWolfAgent;
        wolfAgent.destination = state.shipToDestroy.transform.position;
    }
}
