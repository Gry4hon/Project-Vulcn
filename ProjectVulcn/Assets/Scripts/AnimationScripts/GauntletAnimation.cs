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
    private GameMaster gameMaster;

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

    [Header("Arduino Stuff")]
    public SerialController serialController;

    private bool isOn = false;
    private bool isActive = false;

    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
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
            theTargetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool theAbutton);
            theTargetDevice.TryGetFeatureValue(CommonUsages.trigger, out float rightTriggerVal);
            theTargetDevice.TryGetFeatureValue(CommonUsages.grip, out float rightGripVal);

            gauntletAnimator.SetFloat("Grip", rightGripVal);
            gauntletAnimator.SetFloat("Trigger", rightTriggerVal);

            if (rightGripVal > 0.9 && theAbutton)
            {
                gauntletAnimator.SetFloat("Trigger", rightGripVal * 2f);
                animatePoint.SetActive(true);


            }
            else
            {
                animatePoint.SetActive(false);

            }

            if (theAbutton)
            {
                Debug.Log("Sending A");
                serialController.SendSerialMessage("A");
            }
            else
            {
                Debug.Log("Sending Z");
                serialController.SendSerialMessage("Z");
            }

            if (rightGripVal < 0.9 && theAbutton)
            {
                gauntletCanvas.SetActive(true);
                UISelector.SetActive(true);
            }
            else
            {
                gauntletCanvas.SetActive(false);
                UISelector.SetActive(false);
            }

            string message = serialController.ReadSerialMessage();

            if (message == null)
            {
                return;
            }
            // Check if the message is plain data or a connect/disconnect event.
            if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            {
                Debug.Log("Connection established");
            }

            else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            {
                Debug.Log("Connection attempt failed or disconnection detected");
            }

            else
            {
                Debug.Log("Message arrived: " + message);
            }

        }
        
        if(isOn && !isActive)
        {
            theGauntlet.tag = "Hands";
            Destroy(toDestroy);
            Destroy(gauntletGrabbable);
            Destroy(bodyToDestroy);

            theGauntlet.transform.position = new Vector3(gauntletPoint.transform.position.x, gauntletPoint.transform.position.y, gauntletPoint.transform.position.z);
            theGauntlet.transform.rotation = gauntletPoint.transform.rotation;
            theGauntlet.transform.parent = gauntletPoint.transform;
            toEnable.enabled= true;
            gameMaster.startSpawning = true;
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
