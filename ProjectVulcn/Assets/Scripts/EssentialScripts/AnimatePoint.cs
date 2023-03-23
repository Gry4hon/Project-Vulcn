using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePoint : MonoBehaviour
{
    //This variable is assigned when a piece is socketed

    [Header("Essential Public Objects")]
    public GameObject thePile;
    public GameObject gauntletCanvas;


    CheckPile checkPile;
    ScrapScript destroyScrap;

    bool defenseModeSet = false;
    bool repairModeSet = false;

    public bool isSocketed;



    public void SetToDefenseMode()
    {
        print("Set to Defense Mode");
        defenseModeSet = true;
        repairModeSet = false;
    }

    public void SetToRepairMode()
    {
        print("Set to Repair Mode");
        repairModeSet = true;
        defenseModeSet = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (repairModeSet)
        {
            if (thePile != null)
            {
                if (isSocketed && other.tag == "ScrapPiece")
                {
                    checkPile = other.GetComponent<CheckPile>();
                    if (checkPile.scrapPile.name == thePile.name)
                    {
                        destroyScrap = thePile.GetComponent<ScrapScript>();
                        Destroy(other.gameObject);
                        destroyScrap.SpawnRGolem();
                        isSocketed = false;
                    }
                }
            }
        }

        if (defenseModeSet)
        {

            if (thePile != null)
            {
                if (isSocketed && other.tag == "ScrapPiece")
                {
                    checkPile = other.GetComponent<CheckPile>();
                    if (checkPile.scrapPile.name == thePile.name)
                    {

                        destroyScrap = thePile.GetComponent<ScrapScript>();
                        Destroy(other.gameObject);
                        destroyScrap.SpawnDGolem();
                        isSocketed = false;
                    }
                }
            }
        }

    }
}
