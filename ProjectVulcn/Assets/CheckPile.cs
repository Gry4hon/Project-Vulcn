using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPile : MonoBehaviour
{
    public GameObject scrapPile;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Scrap")
        {
            scrapPile = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Scrap")
        {
            scrapPile = null;
        }
    }
}
