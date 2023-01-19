using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairDeath : RepairStateSetter
{
   // Image healthBar;


    public override void EnterState(RepairStateManager state)
    {
        //healthBar = state.healthBar;
        state.RepairDeath();
    }

    public override void RunCurrentState(RepairStateManager state)
    {
        //Well come back to this later

            
        
    }
}
