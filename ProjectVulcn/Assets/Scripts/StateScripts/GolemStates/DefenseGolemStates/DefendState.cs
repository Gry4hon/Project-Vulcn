using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefendState : DefenseStateSetter
{
    GameObject theTarget;
    NavMeshAgent golemAgent;


    public override void EnterState(DefenseStateManager state)
    {

    }

    public override void RunCurrentState(DefenseStateManager state)
    {
        theTarget = state.scrapWolfTarget;
        golemAgent = state.defenseAgent;
        golemAgent.speed = 2f;

        golemAgent.destination = theTarget.transform.position;

    }
}
