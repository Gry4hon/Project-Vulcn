using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class ScrapWolfManager : MonoBehaviour
{
    ScrapWolfSetter currentState;
    public  ProwlState prowlingState = new ProwlState();
    public HuntState huntState = new HuntState();
    public KillState killState = new KillState();
    public killShipState killShipState = new killShipState();
    public DeathState deathState = new DeathState();

    [Header("The Wolf")]
    public GameObject scrapWolf;
    public NavMeshAgent scrapWolfAgent;
    public BoxCollider searchingHitBox;
    public float wolfHealth = 100f;
    public Image wolfHealthBar;

    [Header("Targets")]
    public GameObject shipToDestroy;
    public GameObject defenseGolemTarget;

    void Start()
    {
        scrapWolf = this.gameObject;
        currentState = prowlingState;
    }

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
        if(other.tag == "Defense")
        {
            defenseGolemTarget = other.gameObject;
            searchingHitBox.enabled = false;
            SwitchState(huntState);
        }

        if(other.tag == "WeakSpot")
        {
            SwitchState(killShipState);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Defense")
        {
            SwitchState(killState);
        }
    }

}
