using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandScript : MonoBehaviour
{
    private InputDevice theTargetDevice;

    [Header("Public GameObjects")]
    public GameObject gauntletCanvas;
    public GameObject animatePoint;
    public GameObject UISelector;

    void Start()
    {
        List<InputDevice> vrControllers = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerChar = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerChar, vrControllers);

        if(vrControllers.Count > 0)
        {
            theTargetDevice = vrControllers[0];
        }
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
    }
}
