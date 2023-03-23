using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemCreationManager : MonoBehaviour
{
    public GameObject thePiece;
    GameObject attachPoint;
    GameObject thisPile;
    public AnimatePoint animatePoint;

    void Start()
    {
        attachPoint = this.transform.GetChild(0).gameObject;
        thisPile = this.gameObject;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Gauntlet") != null)
        {
            animatePoint = GameObject.FindGameObjectWithTag("Gauntlet").GetComponent<AnimatePoint>();
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ScrapPiece" )
        {
            thePiece = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "ScrapPiece")
        {
            if (thePiece != null )
            {
                if (GameObject.FindGameObjectWithTag("Gauntlet") != null)
                {
                    animatePoint.thePile = thisPile;
                    animatePoint.isSocketed = true;
                }
                thePiece.transform.position = attachPoint.transform.position;
                thePiece.transform.rotation = attachPoint.transform.rotation;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "ScrapPiece")
        {
            if (GameObject.FindGameObjectWithTag("Gauntlet") != null)
            {
                animatePoint.thePile = null;
                animatePoint.isSocketed = false;
            }
            thePiece = null;
        }
    }

}
