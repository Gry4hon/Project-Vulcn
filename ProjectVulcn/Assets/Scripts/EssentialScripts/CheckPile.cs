using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPile : MonoBehaviour
{
    public GameObject scrapPile;
    BoxCollider scrapCollider;

    private void Start()
    {
        scrapCollider= GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Scrap")
        {
            scrapPile = other.gameObject;
        }

        if (other.tag == "Hands" || other.tag == "RightHand")
        {
            scrapCollider.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hands" || other.tag == "RightHand")
        {
            scrapCollider.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Scrap")
        {
            scrapPile = null;
        }

        if (other.tag == "Hands")
        {
            scrapCollider.enabled = true;
        }
    }


}
