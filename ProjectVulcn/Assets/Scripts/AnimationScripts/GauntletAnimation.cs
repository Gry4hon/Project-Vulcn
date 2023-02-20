using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GauntletAnimation : MonoBehaviour
{
    private InputDevice theTargetDevice;
    private GameObject theGauntlet;
    private XRGrabInteractable gauntletGrabbable;

    [Header("Essential GameObjects")]
    public BoxCollider toDestroy;
    public Rigidbody bodyToDestroy;
   
    public BoxCollider toEnable;
    public GameObject gauntletPoint;
    public HandScript handScript;


    [Header("Gauntlet GameObjects")]
    public GameObject gauntletCanvas;
    public GameObject UISelector;
    public Animator gauntletAnimator;
    public GameObject animatePoint;

    private bool isOn = false;
    private bool isActive = false;

    void Start()
    {
        List<InputDevice> vrControllers = new List<InputDevice>();
        gauntletGrabbable = GetComponent<XRGrabInteractable>();
        InputDevices.GetDevices(vrControllers);
        theGauntlet = this.gameObject;
        theTargetDevice = vrControllers[2];
    }


    void Update()
    {

        if (isOn)
        {
            theGauntlet.transform.position = new Vector3(gauntletPoint.transform.position.x, gauntletPoint.transform.position.y, gauntletPoint.transform.position.z);

            theTargetDevice.TryGetFeatureValue(CommonUsages.trigger, out float rightTriggerVal);
            theTargetDevice.TryGetFeatureValue(CommonUsages.grip, out float rightGripVal);

            gauntletAnimator.SetFloat("Grip", rightGripVal);
            gauntletAnimator.SetFloat("Trigger", rightTriggerVal);

            theTargetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool theAbutton);
            if (theAbutton)
            {
                gauntletAnimator.SetFloat("Grip", -1) ;
                gauntletCanvas.SetActive(true);
                UISelector.SetActive(true);
                animatePoint.SetActive(true);
            }
            else
            {
                gauntletAnimator.SetFloat("Grip", rightGripVal);
                gauntletCanvas.SetActive(false);
                UISelector.SetActive(false);
                animatePoint.SetActive(false);
            }


        }
        
        if(isOn && !isActive)
        {
            theGauntlet.tag = "Hands";
            Destroy(toDestroy);
            Destroy(gauntletGrabbable);
            Destroy(bodyToDestroy);

            toEnable.enabled= true;
            isActive = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RightHand")
        {
            Destroy(handScript);
            Destroy(other.gameObject);
            isOn = true;
        }
    }
}
