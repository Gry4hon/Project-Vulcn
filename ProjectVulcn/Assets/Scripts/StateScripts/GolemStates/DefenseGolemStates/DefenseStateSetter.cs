using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefenseStateSetter
{
    public abstract void EnterState(DefenseStateManager state);

    public abstract void RunCurrentState(DefenseStateManager state);
}
