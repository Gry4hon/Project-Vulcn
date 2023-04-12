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

    private bool isOn = false;
    private bool isActive = false;

    
    [Header("Arduino Stuff")]
    public SerialController serialController;
    public bool isCharging = false;
    private bool heatActive = false;
    private bool heatInactive = true;

    float redTimer = 5f;
    float yellowTimer = 0f;
    float greenTimer = 0f;

    bool runningRedTimer = true;
    bool runningYellowTimer = false;
    bool runningGreenTimer = false;


    


    void Start()
    {

        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        List<InputDevice> vrControllers = new List<InputDevice>();
        gauntletGrabbable = GetComponent<XRGrabInteractable>();
        InputDevices.GetDevices(vrControllers);
        theGauntlet = this.gameObject;
        theTargetDevice = vrControllers[2];
        //serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
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
                isCharging= true;
                heatInactive = false;
            }
            else
            {
                animatePoint.SetActive(false);
                isCharging= false;
                heatActive= false;

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

        
        if (isCharging)
        {
            LightUpTheNight();
        }

        if(!isCharging&& !heatInactive) 
        {
            serialController.SendSerialMessage("5");
            redTimer = 5f;
            runningRedTimer = true;
            runningYellowTimer = false;
            runningGreenTimer = false;
            print("Running ONLY ONCE");
            heatInactive = true;
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

    
    private void LightUpTheNight()
    {

        if(isCharging && !heatActive)
        {
            serialController.SendSerialMessage("0");
            Debug.Log("STARTING HEAT");
            heatActive = true;
        }


        if (redTimer > 0)
        {
            redTimer -= Time.deltaTime;
            //print("Red Timer: " + redTimer.ToString());
        }else if(redTimer <= 0 && runningRedTimer)
        {
            yellowTimer = 5f;
            runningYellowTimer = true;
           print("Red Timer Done... Going to yellow timer");
            Debug.Log("Sending 1");
            serialController.SendSerialMessage("1");
            runningRedTimer = false;
        }

        if(yellowTimer > 0)
        {
            yellowTimer -= Time.deltaTime;
            //print("Yellow Timer: " + yellowTimer.ToString());
        }else if(yellowTimer <= 0 && runningYellowTimer)
        {
            greenTimer = 5f;
            runningGreenTimer = true;
            //print("Yellow Timer Done... Going to green timer");
            Debug.Log("Sending 2");
            serialController.SendSerialMessage("2");
            runningYellowTimer = false;
        }

        if(greenTimer > 0)
        {
            greenTimer -= Time.deltaTime;
            //print("Green Timer: " + greenTimer.ToString());
        }else if(greenTimer <= 0 && runningGreenTimer)
        {
            print("ALL LEDS ARE ACTIVATED YIPPEEE");
            Debug.Log("Sending 3");
            serialController.SendSerialMessage("3");
            runningGreenTimer = false;
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
    

}
