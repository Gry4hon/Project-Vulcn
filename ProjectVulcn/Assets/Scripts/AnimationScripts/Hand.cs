using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Hand : MonoBehaviour
{
    public float animateSpeed;

    private float gripTarget;
    private float triggerTarget;

    private float currentGripVal;
    private float currentTriggerVal;

    Animator theHandAnimator;


    // Start is called before the first frame update
    void Start()
    {
        theHandAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }

    public void SetGrip(float gripVal)
    {
        gripTarget = gripVal;
    }

    public void SetTrigger(float triggerVal)
    {
        triggerTarget = triggerVal;
    }

    private void AnimateHand()
    {
        if(currentGripVal != gripTarget)
        {
            currentGripVal = Mathf.MoveTowards(currentGripVal, gripTarget, Time.deltaTime * animateSpeed);
            theHandAnimator.SetFloat("Grip", currentGripVal);
        }      
        if(currentTriggerVal != triggerTarget)
        {
            currentTriggerVal = Mathf.MoveTowards(currentTriggerVal, triggerTarget, Time.deltaTime * animateSpeed);
            theHandAnimator.SetFloat("Trigger", currentTriggerVal);
        }
    }


}
