using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDetection : MonoBehaviour
{
    public GameObject theDefenseGolem;

    //DefenseStateManager stateManager;

    private void Update()
    {
        //stateManager = theDefenseGolem.GetComponent<DefenseStateManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ship" || collision.collider.tag == "Scrap")
        {
            //stateManager.directionPick = 4;
        }
    }
}
