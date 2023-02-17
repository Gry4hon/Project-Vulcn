using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : DefenseStateSetter
{

    float waitTime = 5.0f;
    float resetTime;

    bool resetTimerEnded = false;
    bool resetEnded = false;

    bool timerEnded = false;
    bool startWalkin = false;

    bool resetPoints = false;
    float pointTime = 10f;

    public float newGolemX = 0f;
    public float newGolemZ = 0f;

    Vector3 newPosition;
    NavMeshAgent golemAgent;
   

    public float moveSpeed = 1.5f;


    public override void EnterState(DefenseStateManager state)
    {
        state.searchingHitBox.enabled= true;
        state.searchingHitBox.isTrigger = true;
        state.searchingForTarget = true;


       state.scrapWolfTargets.Clear();
        
    }

    public override void RunCurrentState(DefenseStateManager state)
    {
        golemAgent = state.defenseAgent;
        golemAgent.speed = 0.7f;

        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            timerEnded = true;
        }

        if (timerEnded && !startWalkin) {
            startWalkin = true;
            resetTimerEnded = false;
            resetPoints = true;
            resetTime = 2.0f;
            pointTime = 10f;
            newGolemX = RandomCoords(state.defenseGolem.transform.position.x);
            newGolemZ = RandomCoords(state.defenseGolem.transform.position.z);
        }


        if (newGolemX != 0 && newGolemZ != 0)
        {
            if(pointTime > 0 && resetPoints)
            {
                pointTime -= Time.deltaTime;
                newPosition = new Vector3(newGolemX, state.defenseGolem.transform.position.y, newGolemZ);
                golemAgent.destination = newPosition;
            }
            else
            {
                newGolemX= 0;
                newGolemZ= 0;
                startWalkin= false;
            }

        }


        if (state.defenseGolem.transform.position == newPosition)
        {
            resetPoints= false;
            if (resetTime > 0)
            {
                resetTime -= Time.deltaTime;
                resetEnded = false;
            }
            else
            {
                resetTimerEnded = true;
            }

            if(resetTimerEnded && !resetEnded)
            {
                resetEnded= true;
                newGolemX = 0;
                newGolemZ = 0;
                startWalkin = false;
            }
        }

    }

    float RandomCoords(float randomNumber)
    {
        randomNumber += 10;
        randomNumber = Random.Range(-(randomNumber), randomNumber);
        return randomNumber;
    }

    


}
