using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemCreationManager : MonoBehaviour
{
    public GameObject thePiece;
    GameObject attachPoint;
    public AnimatePoint animatePoint;

    // Start is called before the first frame update
    void Start()
    {
        attachPoint = this.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Gauntlet") != null)
        {
            animatePoint = GameObject.FindGameObjectWithTag("Gauntlet").GetComponent<AnimatePoint>();
        }
    }

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Gauntlet") != null)
        {
            animatePoint = GameObject.FindGameObjectWithTag("Gauntlet").GetComponent<AnimatePoint>();
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "ScrapPiece")
        {
            if (animatePoint != null)
            {
                animatePoint.isSocketed = true;
                animatePoint.thePile = this.gameObject;
            }
            thePiece = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "ScrapPiece")
        {
            if (thePiece != null)
            {
                if (animatePoint != null)
                {
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
            if (animatePoint != null)
            {
                animatePoint.thePile = null;
                animatePoint.isSocketed = true;
            }
            thePiece = null;
        }
    }

}
