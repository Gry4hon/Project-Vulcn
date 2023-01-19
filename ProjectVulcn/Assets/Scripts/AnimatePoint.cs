using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePoint : MonoBehaviour
{
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
        theHead = thePile.gameObject.GetComponentInChildren<IsSocketed>();
        golemMode = gauntletCanvas.GetComponent<CanvasManager>();
    }

    private void Update()
    {
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
                Destroy(other.gameObject);
                destroyScrap.SpawnRGolem();
                isSocketed = false;
            }
        }

        if (defenseMode)
        {
            if (isSocketed && other.tag == ("Chip"))
            {
                Destroy(other.gameObject);
                destroyScrap.SpawnDGolem();
                isSocketed = false;
            }
        }

    }
}
