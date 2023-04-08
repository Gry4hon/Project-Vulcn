using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroObjectScript : MonoBehaviour
{

    GameObject grabbedObject;
    BoxCollider grabbedObjectCollider;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            grabbedObject = other.gameObject;
            grabbedObjectCollider = grabbedObject.GetComponent<BoxCollider>();
            grabbedObjectCollider.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            grabbedObject = other.gameObject;
            grabbedObjectCollider = grabbedObject.GetComponent<BoxCollider>();
            grabbedObjectCollider.enabled = false;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Grabbable")
        {
            grabbedObjectCollider.enabled = true;
            grabbedObjectCollider = null;
            grabbedObject = null;
        }
    }

    
}
