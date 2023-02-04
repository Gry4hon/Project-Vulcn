using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class IsSocketed : MonoBehaviour
{

    public bool pieceSocketed = false;

   public AnimatePoint animatePoint;

    bool isLooking = true;

   //public GameObject animatePoint;
    public GameObject scrapPile;


    //When the game starts all the scrap piles will assign the animatePoint to a gameobject that is attached to the gauntlet that allows for golem animation
    //Then it grabs the AnimatePoint script from that object

    

    /*
    private void Update()
    {
        if (animatePoint == null)
        {
           animatePoint =  GameObject.Find("AnimatePoint").GetComponent<AnimatePoint>();
            isLooking= true;
        }
        else if(animatePoint != null && isLooking) {
            isLooking = false;
            print("found ittttt");
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        //Then if a chip is present in the box collider it sets the gameobject variable in AnimatePoint to equal the scrap pile this socket is a child of
        //Then it sets the piece socketed value on this specific head to be valid.
 
        
            if (other.tag == "Chip")
            {
                    animatePoint.thePile = scrapPile;
                    pieceSocketed = true;
                    animatePoint.UpdatePile();
            }
        

    }
}
