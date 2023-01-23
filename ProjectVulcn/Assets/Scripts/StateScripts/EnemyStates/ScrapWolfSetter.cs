using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScrapWolfSetter
{
    public abstract void EnterState(ScrapWolfManager state);

    public abstract void RunCurrentState(ScrapWolfManager state);
}
