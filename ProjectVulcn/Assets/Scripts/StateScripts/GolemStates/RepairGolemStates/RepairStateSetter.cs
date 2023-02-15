using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RepairStateSetter
{

    public abstract void EnterState(RepairStateManager state);

    public abstract void RunCurrentState(RepairStateManager state);

}

