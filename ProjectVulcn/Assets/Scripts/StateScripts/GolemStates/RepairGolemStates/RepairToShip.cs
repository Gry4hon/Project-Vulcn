using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RepairToShip : RepairStateSetter
{
    Vector3 starSkipperLocation;
    //GameObject theGolem;

    NavMeshAgent golemAgent;


    public override void EnterState(RepairStateManager state)
    {

    }

    public override void RunCurrentState(RepairStateManager state)
    {

        golemAgent = state.repairAgent;
        //theGolem = state.theRepairGolem;


        //starSkipperLocation = new Vector3(state.theShip.transform.position.x, 10f, state.theShip.transform.position.z);


        golemAgent.destination = state.theShip.transform.position;
    }
}
