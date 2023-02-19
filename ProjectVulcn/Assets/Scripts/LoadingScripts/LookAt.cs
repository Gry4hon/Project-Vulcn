using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    GameObject thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thePlayer = GameObject.FindGameObjectWithTag("MainCamera");

        this.transform.LookAt(thePlayer.transform.position);
    }
}
