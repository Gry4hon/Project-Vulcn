using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HuntState : ScrapWolfSetter
{
    NavMeshAgent wolfAgent;
    GameObject golemToKill;


    public override void EnterState(ScrapWolfManager state)
    {

    }

    public override void RunCurrentState(ScrapWolfManager state)
    {
            wolfAgent = state.scrapWolfAgent;
            wolfAgent.speed = 4f;
            golemToKill = state.defenseGolemTarget;
            wolfAgent.destination = golemToKill.transform.position;
    }
}
