using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LeftHandAnimator : MonoBehaviour
{

    public Animator leftAnimator;
    private InputDevice theTargetDevice;
    [SerializeField] private GameObject pauseMenu;
    //public GameObject playerRayCast;


    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> vrControllers = new List<InputDevice>();

        InputDevices.GetDevices(vrControllers);

        theTargetDevice = vrControllers[1];


    }

    // Update is called once per frame
    void Update()
    {
        theTargetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool theXbutton);
        theTargetDevice.TryGetFeatureValue(CommonUsages.trigger, out float leftTriggerVal);
        theTargetDevice.TryGetFeatureValue(CommonUsages.grip, out float leftGripVal);



        leftAnimator.SetFloat("Grip", leftGripVal);
        leftAnimator.SetFloat("Trigger", leftTriggerVal);

        if (theXbutton)
        {
            
            pauseMenu.SetActive(true);
            //playerRayCast.SetActive(true);
            Time.timeScale = 0f;
            
        }
        else
        {
            
            pauseMenu.SetActive(false);
            //playerRayCast.SetActive(false);
            Time.timeScale = 1f;
            
        }

    }
}
