using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendState : DefenseStateSetter
{
    GameObject theTarget;
    Vector3 targetLocation;
    public override void EnterState(DefenseStateManager state)
    {

    }

    public override void RunCurrentState(DefenseStateManager state)
    {
        theTarget = state.enemyList[0];

        targetLocation = new Vector3(theTarget.transform.position.x - 0.5f, state.defenseGolem.transform.position.y, theTarget.transform.position.z);

        state.defenseGolem.transform.position = Vector3.MoveTowards(state.defenseGolem.transform.position, targetLocation, 2f * Time.deltaTime);

        if(state.defenseGolem.transform.position == targetLocation)
        {
            state.SwitchState(state.attackState);
        }
    }
}
