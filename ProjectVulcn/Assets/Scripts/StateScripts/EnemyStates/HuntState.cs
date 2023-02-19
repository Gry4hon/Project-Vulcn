using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HuntState : ScrapWolfSetter
{
    NavMeshAgent wolfAgent;
    public GameObject golemToKill;


    public override void EnterState(ScrapWolfManager state)
    {

    }

    public override void RunCurrentState(ScrapWolfManager state)
    {
            wolfAgent = state.scrapWolfAgent;
            wolfAgent.speed = 2.5f;
            golemToKill = state.defenseGolemTargets[0];


        if(golemToKill!= null ) 
        {
            wolfAgent.destination = golemToKill.transform.position;
        }
        else
        {
            state.SwitchState(state.prowlingState);
        }
    }
}
