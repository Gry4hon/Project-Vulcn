using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    GameObject thePlayer;

    void Update()
    {
        thePlayer = GameObject.FindGameObjectWithTag("MainCamera");
        this.transform.LookAt(thePlayer.transform.position);
    }
}
