using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : DefenseStateSetter
{
    /*What I want this script to do:
     * 
     * 1. On enter, get the position of the defenseGolem
     * 2. While running, have the transform change randomly as though it was wandering
     * 2.5 Perhaps an array of different randomly assigned 
     * 
     * 
     */



    public override void EnterState(DefenseStateManager state)
    {

    }

    public override void RunCurrentState(DefenseStateManager state)
    {
        state.SwitchState(state.wanderState);



        
           
    }
}
