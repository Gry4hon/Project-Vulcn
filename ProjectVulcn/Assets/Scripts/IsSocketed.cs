using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class IsSocketed : MonoBehaviour
{

    public bool pieceSocketed = false;

    AnimatePoint setGameObject;

    public GameObject animatePoint;
    public GameObject scrapPile;

    private void Start()
    {
        setGameObject = animatePoint.GetComponent<AnimatePoint>();

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Chip")
        {
            setGameObject.thePile = scrapPile;
            pieceSocketed = true;
        }
    }
}
