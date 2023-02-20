using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemCreationManager : MonoBehaviour
{
    public GameObject thePiece;

    GameObject attachPoint;


    AnimatePoint animatePoint;



    // Start is called before the first frame update
    void Start()
    {
        attachPoint = this.transform.GetChild(0).gameObject;
        animatePoint = GameObject.Find("AnimatePoint").GetComponent<AnimatePoint>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ScrapPiece")
        {
            animatePoint.isSocketed = true;
            animatePoint.thePile = this.gameObject;
            thePiece = other.gameObject;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "ScrapPiece")
        {
            animatePoint.isSocketed = true;
            thePiece.transform.position = attachPoint.transform.position;
            thePiece.transform.rotation = attachPoint.transform.rotation;
        }
    }

    private void OnTriggerExit(Collider other)
 {
     if(other.tag == "ScrapPiece")
     {
            animatePoint.thePile = null;
            animatePoint.isSocketed = true;
            thePiece = null;
        }
 }
 

}
