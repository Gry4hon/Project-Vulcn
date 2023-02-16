using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KillState : ScrapWolfSetter
{
    NavMeshAgent wolfAgent;
    GameObject theWolf;

    GameObject theTarget;
    DefenseStateManager defenseState;

    bool isKilling;

    public override void EnterState(ScrapWolfManager state)
    {
        wolfAgent = state.scrapWolfAgent;
        theWolf = state.scrapWolf;

        theTarget = state.defenseGolemTarget;
        defenseState = theTarget.GetComponent<DefenseStateManager>();
        isKilling= true;
        state.StartCoroutine(KillGolem());
    }

    private IEnumerator KillGolem()
    {
        while (isKilling)
        {
            yield return new WaitForSeconds(3);
            defenseState.golemHealth -= 2f;
            defenseState.golemHealthBar.fillAmount = defenseState.golemHealth / 100f;
        }
    }

    public override void RunCurrentState(ScrapWolfManager state)
    {
        wolfAgent.destination = theWolf.transform.position;

        if (defenseState.golemHealth <= 0) 
        {
            isKilling = false;
            state.StopCoroutine(KillGolem());
            state.SwitchState(state.prowlingState);
        }

        if(state.wolfHealth <= 0)
        {
            isKilling = false;
            state.StopCoroutine(KillGolem());
            state.SwitchState(state.deathState);
        }
    }
}
