using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapWolfManager : MonoBehaviour
{
    ScrapWolfSetter currentState;

    ProwlState prowlingState = new ProwlState();
    public GameObject scrapWolf;

    public Vector3 wolfPosition;
    void Start()
    {
        currentState = prowlingState;
        scrapWolf = this.gameObject;
        wolfPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.RunCurrentState(this);

        
    }

    public void SwitchState(ScrapWolfSetter nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
