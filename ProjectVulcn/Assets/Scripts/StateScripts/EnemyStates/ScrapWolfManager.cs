using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScrapWolfManager : MonoBehaviour
{
    ScrapWolfSetter currentState;

    ProwlState prowlingState = new ProwlState();
    HuntState huntState = new HuntState();
    KillState killState = new KillState();
    DeathState deathState = new DeathState();

    public GameObject scrapWolf;

    public GameObject shipToDestroy;
    public NavMeshAgent scrapWolfAgent;

    public Vector3 wolfPosition;
    void Start()
    {
        scrapWolf = this.gameObject;


        currentState = prowlingState;

        //wolfPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        shipToDestroy = GameObject.FindGameObjectWithTag("WeakSpot");
        scrapWolfAgent = GetComponent<NavMeshAgent>();

        currentState.RunCurrentState(this);

        
    }

    public void SwitchState(ScrapWolfSetter nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WeakSpot")
        {
            SwitchState(killState);
        }
    }

}
