using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefenceAttackState : DefenseStateSetter
{
    NavMeshAgent golemAgent;
    GameObject theGolem;


    GameObject theTarget;
    ScrapWolfManager scrapWolfManager;

    bool isAttacking;
    bool noTarget = false;

    public override void EnterState(DefenseStateManager state)
    {
        golemAgent = state.defenseAgent;
        theGolem = state.defenseGolem;


        theTarget = state.scrapWolfTargets[0];
        scrapWolfManager = theTarget.GetComponent<ScrapWolfManager>();



        isAttacking = true;
        state.StartCoroutine(DoDamage());
    }


    private IEnumerator DoDamage()
    {
        if(theTarget!= null)
        {
            while (isAttacking)
            {
                yield return new WaitForSeconds(2);
                scrapWolfManager.wolfHealth -= 10f;
                scrapWolfManager.wolfHealthBar.fillAmount = scrapWolfManager.wolfHealth / 100f;
            }
        }
        else
        {
            noTarget= true;
        }

    }

    public override void RunCurrentState(DefenseStateManager state)
    {

        if (scrapWolfManager.wolfHealth <= 0)
        {
            isAttacking= false;
            state.firstBlood= true;
            state.StopCoroutine(DoDamage());
            state.SwitchState(state.wanderState);
        }

        if(state.golemHealth <= 0)
        {
            isAttacking= false;
            state.StopCoroutine(DoDamage());
        }

        if (noTarget)
        {
            isAttacking = false;
            state.StopCoroutine(DoDamage());
            state.SwitchState(state.wanderState);
        }


    }
}
