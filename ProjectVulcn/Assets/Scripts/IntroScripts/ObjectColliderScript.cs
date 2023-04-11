using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColliderScript : MonoBehaviour
{

    public GameObject attachedObject;
    public BoxCollider objectsCollider;
    // Start is called before the first frame update
    void Update()
    {
        attachedObject = this.gameObject;
        objectsCollider = attachedObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hands")
        {
            objectsCollider.enabled = false;
        }
    }


    private void OnTriggerExit(Collider other)
    {

        if(!objectsCollider.enabled) {
            objectsCollider.enabled = true;

        }

        if (other.tag == "Hands")
        {
            print("ssikfikesdkfg");
        }

    }
}
