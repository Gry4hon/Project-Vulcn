using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceAttackState : DefenseStateSetter
{
    public override void EnterState(DefenseStateManager state)
    {
        Debug.Log("Attacking grr bark bark");
    }

    public override void RunCurrentState(DefenseStateManager state)
    {

    }
}
