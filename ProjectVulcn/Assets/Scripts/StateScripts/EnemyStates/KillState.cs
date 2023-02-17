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
    bool noTarget = false;

    public override void EnterState(ScrapWolfManager state)
    {
        wolfAgent = state.scrapWolfAgent;
        theWolf = state.scrapWolf;

        theTarget = state.defenseGolemTargets[0];
        defenseState = theTarget.GetComponent<DefenseStateManager>();

        isKilling= true;
        state.StartCoroutine(KillGolem());
    }

    private IEnumerator KillGolem()
    {
        if(theTarget != null)
        {
            while (isKilling)
            {
                yield return new WaitForSeconds(4);
                defenseState.golemHealth -= 2f;
                defenseState.golemHealthBar.fillAmount = defenseState.golemHealth / 100f;
            }
        }
        else
        {
            noTarget= true;
        }

    }

    public override void RunCurrentState(ScrapWolfManager state)
    {
        wolfAgent.destination = theWolf.transform.position;

        if (defenseState.golemHealth <= 0) 
        {
            isKilling = false;
            state.firstBlood= true;
            state.StopCoroutine(KillGolem());
            state.SwitchState(state.prowlingState);
        }

        if (noTarget)
        {
            isKilling = false;
            state.StopCoroutine(KillGolem());
            state.SwitchState(state.prowlingState);
        }

    }
}
