using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairToShip : RepairStateSetter
{
    /*
     * What this script needs to do:
     * 
     * 1. when this state is entered, get the transform of the ship
     * 2. when this state is running, move towards the ship
     * 3. when this object collides with the ship, enter into the repair state
     */
    GameObject theShip;
    GameObject theGolem;


    public override void EnterState(RepairStateManager state)
    {
        theShip = GameObject.Find("VulcnStarSkipper");
        theGolem = state.theRepairGolem;
    }

    public override void RunCurrentState(RepairStateManager state)
    {
        state.SwitchState(state.moveState);
        
        theGolem.transform.position = Vector3.MoveTowards(theGolem.transform.position, theShip.transform.position, 1.5f * Time.deltaTime);
    }
}
