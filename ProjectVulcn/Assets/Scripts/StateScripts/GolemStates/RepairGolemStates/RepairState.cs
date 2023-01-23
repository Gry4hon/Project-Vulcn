using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairState : RepairStateSetter
{
    Image repairBar;

    float repairTimer = 2f;

    bool repairing = true;
    bool runTimer = true;

    public override void EnterState(RepairStateManager state)
    {
        repairBar = state.repairBar;
        repairBar.fillAmount = 0;
    }

    public override void RunCurrentState(RepairStateManager state)
    {
        if (runTimer)
        {
            if (repairTimer >= 0)
            {
                repairTimer -= Time.deltaTime;
            }
            else
            {
                repairTimer = 2f;
                repairBar.fillAmount += 0.1f;
            }
        }
       

        if(repairBar.fillAmount >= 1.0f && repairing)
        {
            repairing = false;
            runTimer = false;
            state.SwitchState(state.deathState);
        }

    }
}
