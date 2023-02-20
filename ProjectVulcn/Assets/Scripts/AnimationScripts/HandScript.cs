using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandScript : MonoBehaviour
{
    private InputDevice theTargetDevice;


    public Animator rightAnimator;

    void Start()
    {
        List<InputDevice> vrControllers = new List<InputDevice>();
       
        InputDevices.GetDevices(vrControllers);

        theTargetDevice = vrControllers[2];
    }


    void Update()
    {
        
        theTargetDevice.TryGetFeatureValue(CommonUsages.trigger, out float rightTriggerVal);
        theTargetDevice.TryGetFeatureValue(CommonUsages.grip, out float rightGripVal);


        
        rightAnimator.SetFloat("Grip", rightGripVal);   
        rightAnimator.SetFloat("Trigger", rightTriggerVal);   




    }
}
