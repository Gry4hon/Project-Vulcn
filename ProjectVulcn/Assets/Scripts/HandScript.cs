using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandScript : MonoBehaviour
{
    private InputDevice theTargetDevice;
    private InputDevice theSecondaryDevice;

    public Animator rightAnimator;
    public Animation rightGrip;

   

    [Header("Public GameObjects")]
    public GameObject gauntletCanvas;
    public GameObject animatePoint;
    public GameObject UISelector;

    void Start()
    {
        List<InputDevice> vrControllers = new List<InputDevice>();
       
        InputDevices.GetDevices(vrControllers);

        theTargetDevice = vrControllers[2];
        theSecondaryDevice= vrControllers[1];
    }


    void Update()
    {

        theTargetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool theAbutton);
        if (theAbutton)
        {
            gauntletCanvas.SetActive(true);
            animatePoint.SetActive(true);
            UISelector.SetActive(true);
        }
        else
        {
            animatePoint.SetActive(false);
            gauntletCanvas.SetActive(false);
            UISelector.SetActive(false);
        }

        theTargetDevice.TryGetFeatureValue(CommonUsages.trigger, out float rightTriggerVal);
        theTargetDevice.TryGetFeatureValue(CommonUsages.grip, out float rightGripVal);

        theSecondaryDevice.TryGetFeatureValue(CommonUsages.trigger, out float leftTriggerVal);
        theSecondaryDevice.TryGetFeatureValue(CommonUsages.grip, out float leftGripVal);

        
        rightAnimator.SetFloat("Grip", rightGripVal);   
        rightAnimator.SetFloat("Trigger", rightTriggerVal);   




    }
}
