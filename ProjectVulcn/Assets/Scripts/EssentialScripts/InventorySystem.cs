using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class InventorySystem : MonoBehaviour
{
    private GameObject backPack;
    private BoxCollider packCollider;
    private Rigidbody packBody;
    private XRGrabInteractable packGrabbable;

    public GameObject packPrefab;

    private Vector3 backPosition;
    private GameObject backRef;
    private bool packIsOn = false;

    private void Start()
    {
        backRef = this.gameObject;
    }

    void Update()
    {
        backPack = GameObject.FindGameObjectWithTag("backpack");
        packCollider = backPack.GetComponent<BoxCollider>();
        packGrabbable = backPack.GetComponent<XRGrabInteractable>();
        packBody = backPack.GetComponent<Rigidbody>();
        //backPosition = new Vector3(backRef.transform.position.x, backRef.transform.position.y, backRef.transform.position.z);

        

        if (packIsOn && packCollider != null)
        {
            /*
             gameObj.transform.eulerAngles = new Vector3(
            gameObj.transform.eulerAngles.x,
            gameObj.transform.eulerAngles.y + 180,
            gameObj.transform.eulerAngles.z

                        backPack.transform.eulerAngles = new Vector3(
                backPack.transform.eulerAngles.x + 80.2363663f,
                backPack.transform.eulerAngles.y + 165.041458f,
                backPack.transform.eulerAngles.z + 72.2627869f
                );
             */



            backPack.transform.parent = backRef.transform;

            backPack.transform.rotation = backRef.transform.rotation;
            backPack.transform.position = backRef.transform.position;


            //backPack.transform.Rotate(Vector3.zero);

            Destroy(packGrabbable);
            Destroy(packBody);
            Destroy(packCollider);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "BackPack")
        {
            SpawnPack();
        }
    }

    private void SpawnPack()
    {
        Destroy(backPack);
        Instantiate(packPrefab);
        packIsOn = true;
        //print(backRef.transform.eulerAngles);

    }

}


