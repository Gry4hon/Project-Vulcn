using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefenceAttackState : DefenseStateSetter
{
    NavMeshAgent golemAgent;
    GameObject theGolem;
    Rigidbody golemRigidBody;

    GameObject theTarget;
    ScrapWolfManager scrapWolfManager;

    bool isAttacking;

    public override void EnterState(DefenseStateManager state)
    {
        Debug.Log("Made it to Attack State");
        golemAgent = state.defenseAgent;
        theGolem = state.defenseGolem;


        theTarget = state.scrapWolfTarget;
        scrapWolfManager = theTarget.GetComponent<ScrapWolfManager>();

        golemRigidBody = theGolem.GetComponent<Rigidbody>();

        golemAgent.destination = theGolem.transform.position;
        golemRigidBody.constraints = RigidbodyConstraints.FreezePosition;

        isAttacking = true;
        state.StartCoroutine(DoDamage());
    }


    private IEnumerator DoDamage()
    {
        while (isAttacking)
        {
            yield return new WaitForSeconds(5);
            scrapWolfManager.wolfHealth -= 10f;
            scrapWolfManager.wolfHealthBar.fillAmount = scrapWolfManager.wolfHealth / 100f;
        }
    }

    public override void RunCurrentState(DefenseStateManager state)
    {

        if (scrapWolfManager.wolfHealth <= 0)
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
