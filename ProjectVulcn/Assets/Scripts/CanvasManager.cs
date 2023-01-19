using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public bool defenseModeSet = false;
    public bool repairModeSet = false;

    public void SetToDefenseMode()
    {
        print("Set to Defensive Mode");
        defenseModeSet = true;
        repairModeSet = false;
    }

    public void SetToRepairMode()
    {
        print("Set to Repair Mode");
        repairModeSet = true;
        defenseModeSet = false;
    }

}
