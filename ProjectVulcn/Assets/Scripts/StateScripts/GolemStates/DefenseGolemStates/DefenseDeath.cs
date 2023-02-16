using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseDeath : DefenseStateSetter
{
    public override void EnterState(DefenseStateManager state)
    {
        Object.Destroy(state.defenseGolem);
    }

    public override void RunCurrentState(DefenseStateManager state)
    {

    }
}
