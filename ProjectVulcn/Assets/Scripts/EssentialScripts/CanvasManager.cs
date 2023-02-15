using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public bool defenseModeSet = false;
    public bool repairModeSet = false;

    public void SetToDefenseMode()
    {
        defenseModeSet = true;
        repairModeSet = false;
    }

    public void SetToRepairMode()
    {
        repairModeSet = true;
        defenseModeSet = false;
    }

}
