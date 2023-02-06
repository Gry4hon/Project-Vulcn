using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GolemCreationSetter
{
    public abstract void EnterState(GolemCreationManager state);

    public abstract void RunCurrentState(GolemCreationManager state);
}