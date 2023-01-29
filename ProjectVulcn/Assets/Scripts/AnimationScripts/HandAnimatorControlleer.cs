using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]

public class HandAnimatorControlleer : MonoBehaviour
{

    ActionBasedController vrController;
    public Hand theHand;


    void Start()
    {
        vrController= GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        theHand.SetGrip(vrController.selectAction.action.ReadValue<float>()); 
        theHand.SetTrigger(vrController.activateAction.action.ReadValue<float>());
    }
}
