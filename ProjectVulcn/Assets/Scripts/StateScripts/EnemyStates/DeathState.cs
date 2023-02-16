using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : ScrapWolfSetter
{
    public override void EnterState(ScrapWolfManager state)
    {
        Object.Destroy(state.scrapWolf);
    }

    public override void RunCurrentState(ScrapWolfManager state)
    {

    }
}
