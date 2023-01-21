using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : DefenseStateSetter
{
    /*What I want this script to do:
     * 1. On enter, get the position of the defenseGolem
     * 2. While running, have the transform change randomly as though it was wandering
     * 2.5 Perhaps an array of different randomly assigned 
     */
    float waitTime = 5.0f;
    float resetTime;

    bool resetTimerEnded = false;
    bool resetEnded = false;

    bool timerEnded = false;
    bool startWalkin = false;

    public float newGolemX = 0f;
    public float newGolemZ = 0f;

    Vector3 newPosition;

    public float moveSpeed = 1.5f;


    public override void EnterState(DefenseStateManager state)
    {
    }

    public override void RunCurrentState(DefenseStateManager state)
    {
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            timerEnded = true;
        }


        if (timerEnded && !startWalkin) {
            state.defenseGolem.transform.Rotate(0.0f, 0.0f,0.0f);
            startWalkin = true;
             resetTimerEnded= false;
             resetTime = 2.0f;
             newGolemX = RandomCoords(state.defenseLocation.x);
             newGolemZ = RandomCoords(state.defenseLocation.z);


        }



        if(newGolemX != 0 && newGolemZ != 0)
        {

            newPosition = new Vector3(newGolemX, state.defenseGolem.transform.position.y, newGolemZ);
            

            state.defenseGolem.transform.position = Vector3.MoveTowards(state.defenseGolem.transform.position, newPosition, moveSpeed * Time.deltaTime);

        }

        if (state.defenseGolem.transform.position == newPosition)
        {
            if(resetTime > 0)
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
