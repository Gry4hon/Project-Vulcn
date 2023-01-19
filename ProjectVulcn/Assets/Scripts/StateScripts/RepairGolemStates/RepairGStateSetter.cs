using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RepairStateSetter
{
    //This is setting up the componets that are required for scripts utilzing this class


    public abstract void EnterState(RepairStateManager state);

    public abstract void RunCurrentState(RepairStateManager state);

}
