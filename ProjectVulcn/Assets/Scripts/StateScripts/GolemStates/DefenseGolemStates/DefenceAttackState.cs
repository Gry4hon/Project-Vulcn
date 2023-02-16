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

    public override void EnterState(DefenseStateManager state)
    {
        Debug.Log("INITIATING ATTACK");
        golemAgent = state.defenseAgent;
        theGolem = state.defenseGolem;
        golemAgent.destination = theGolem.transform.position;

        theTarget = state.scrapWolfTarget;
        scrapWolfManager = theTarget.GetComponent<ScrapWolfManager>();

        isAttacking=true;
        state.StartCoroutine(DoDamage());
    }


    private IEnumerator DoDamage()
    {
        while (isAttacking)
        {
            yield return new WaitForSeconds(5);
            scrapWolfManager.wolfHealth -= 10f;
            Debug.Log("Wolf Heath: " + scrapWolfManager.wolfHealth);
            scrapWolfManager.wolfHealthBar.fillAmount = scrapWolfManager.wolfHealth / 100f;
        }
    }

    public override void RunCurrentState(DefenseStateManager state)
    {
        if(scrapWolfManager.wolfHealth <= 0)
        {
            isAttacking= false;
            state.StopCoroutine(DoDamage());
            state.SwitchState(state.wanderState);
        }

        if(state.golemHealth <= 0)
        {
            isAttacking= false;
            state.StopCoroutine(DoDamage());
            state.SwitchState(state.defenseDeath);
        }
    }
}
