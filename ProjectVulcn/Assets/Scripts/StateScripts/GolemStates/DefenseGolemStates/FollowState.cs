using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowState : DefenseStateSetter
{
    NavMeshAgent defenseAgent;
    public override void EnterState(DefenseStateManager state)
    {
        state.searchingHitBox.enabled = true;
        state.searchingHitBox.isTrigger = true;
        state.searchingForTarget = true;
    }

    public override void RunCurrentState(DefenseStateManager state)
    {
        defenseAgent = state.defenseAgent;
        defenseAgent.speed = 1.5f;
        defenseAgent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
