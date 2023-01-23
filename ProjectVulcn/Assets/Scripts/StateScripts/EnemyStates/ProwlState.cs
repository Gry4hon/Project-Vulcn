using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProwlState : ScrapWolfSetter
{

    float waitTime = 2.0f;
    float resetTime;

    bool resetTimerEnded = false;
    bool resetEnded = false;

    bool timerEnded = false;
    bool startProwl = false;

    Vector3 newLocation;

    public float newWolfX = 0.0f;
    public float newWolfZ = 0.0f;

    public float moveSpeed = 2.0f;

    public override void EnterState(ScrapWolfManager state)
    {

    }

    public override void RunCurrentState(ScrapWolfManager state)
    {
        if(waitTime> 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            timerEnded= true;
        }


        if(timerEnded && !startProwl)
        {
            startProwl= true;
            resetTimerEnded = true;
            resetTime = 1.0f;

            newWolfX = RandomCoords(state.wolfPosition.x);
            newWolfZ = RandomCoords(state.wolfPosition.z);

            Debug.Log("Wolf X: " + newWolfX + " Wolf Y: " + newWolfZ);
        }

        if(newWolfX != 0 && newWolfZ != 0)
        {
            newLocation = new Vector3(newWolfX, state.scrapWolf.transform.position.y, newWolfZ);

            state.scrapWolf.transform.position = Vector3.MoveTowards(state.scrapWolf.transform.position, newLocation, moveSpeed * Time.deltaTime);
            state.scrapWolf.transform.LookAt(newLocation);

        }

        if(state.scrapWolf.transform.position == newLocation)
        {
            if(resetTime > 0)
            {
                resetTime -= Time.deltaTime;
                resetEnded= false;
            }
            else
            {
                resetTimerEnded= true;
            }

            if(resetTimerEnded && !resetEnded)
            {
                newWolfX = 0f;
                newWolfZ = 0f;
                startProwl = false;
                resetEnded= true;
            }
        }











    }


    float RandomCoords(float randomNumber)
    {
        //randomNumber += 5;
        randomNumber = Random.Range(-(randomNumber), randomNumber);
        return randomNumber;
    }

}
