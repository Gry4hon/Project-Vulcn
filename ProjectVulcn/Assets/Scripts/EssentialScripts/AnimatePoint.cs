using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting;
using UnityEngine;

public class AnimatePoint : MonoBehaviour
{
    //This variable is assigned when a piece is socketed
    public GameObject thePile;


    public GameObject gauntletCanvas;


   CheckPile checkPile;
    ScrapScript destroyScrap;

    CanvasManager golemMode;

    public bool isSocketed;
    bool defenseMode = false;
    bool repairMode = false;

    private void Start()
    {
        golemMode = gauntletCanvas.GetComponent<CanvasManager>();
    }



    private void OnTriggerEnter(Collider other)
    {
        repairMode = golemMode.repairModeSet;
        defenseMode = golemMode.defenseModeSet;

        if (repairMode)
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

        if (defenseMode)
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
