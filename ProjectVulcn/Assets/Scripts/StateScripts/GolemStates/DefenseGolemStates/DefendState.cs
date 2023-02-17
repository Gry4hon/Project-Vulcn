using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefendState : DefenseStateSetter
{
    public GameObject theTarget;
    NavMeshAgent golemAgent;


    public override void EnterState(DefenseStateManager state)
    {
        //state.targetFound= true;
    }

    public override void RunCurrentState(DefenseStateManager state)
    {
        theTarget = state.scrapWolfTargets[0];
        golemAgent = state.defenseAgent;
        golemAgent.speed = 2f;

        if(theTarget!= null)
        {
            golemAgent.destination = theTarget.transform.position;
        }
        else
        {
            state.SwitchState(state.wanderState);
        }


    }

    
}
