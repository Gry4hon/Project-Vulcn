using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePoint : MonoBehaviour
{
    //This variable is assigned when a piece is socketed
    public GameObject thePile;

    public GameObject gauntletCanvas;

    IsSocketed theHead;
    ScrapScript destroyScrap;

    CanvasManager golemMode;

   bool isSocketed;
   bool defenseMode = false;
    bool repairMode = false;

    private void Start()
    {
        golemMode = gauntletCanvas.GetComponent<CanvasManager>();
    }


    public void UpdatePile()
    {
        theHead = thePile.gameObject.GetComponentInChildren<IsSocketed>();
        isSocketed = theHead.pieceSocketed;
    }

    private void OnTriggerEnter(Collider other)
    {
        destroyScrap = thePile.GetComponent<ScrapScript>();

        repairMode = golemMode.repairModeSet;
        defenseMode = golemMode.defenseModeSet;

        if (repairMode)
        {
            if (isSocketed && other.tag == ("Chip"))
            {
                print("Repair golem is created");
                Destroy(other.gameObject);
                destroyScrap.SpawnRGolem();
                isSocketed = false;
            }
        }

        if (defenseMode)
        {

            if (isSocketed && other.tag == ("Chip"))
            {
                print("Defense golem is created");
                Destroy(other.gameObject);
                destroyScrap.SpawnDGolem();
                isSocketed = false;
            }
        }

    }
}
