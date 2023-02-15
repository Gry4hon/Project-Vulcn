using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillState : ScrapWolfSetter
{
    public override void EnterState(ScrapWolfManager state)
    {
        Debug.Log("LMFAOOOO grrr Im attacking the ship!!!!");
    }

    public override void RunCurrentState(ScrapWolfManager state)
    {

    }
}
