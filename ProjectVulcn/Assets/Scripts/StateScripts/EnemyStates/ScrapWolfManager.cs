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

    GameObject theGameMaster;
    public GameMaster gameMaster;

    [Header("The Wolf")]
    public GameObject scrapWolf;
    public NavMeshAgent scrapWolfAgent;
    public BoxCollider searchingHitBox;
    public float wolfHealth = 100f;
    public Image wolfHealthBar;

    public bool targetFound = false;
    public bool searchingForTarget = true;
    public bool firstBlood = false;

    [Header("Targets")]
    public GameObject shipToDestroy;
    public List<GameObject> defenseGolemTargets = new List<GameObject>();


    void Start()
    {
        scrapWolf = this.gameObject;
        scrapWolfAgent = GetComponent<NavMeshAgent>();
        shipToDestroy = GameObject.FindGameObjectWithTag("WeakSpot");
        currentState = prowlingState;

        theGameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        gameMaster = theGameMaster.GetComponent<GameMaster>();
    }

    void Update()
    {

        currentState.RunCurrentState(this);

        if(wolfHealth <= 0)
        {
            GameObject.Destroy(scrapWolf);
        }
    }

    public void SwitchState(ScrapWolfSetter nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject == huntState.golemToKill && targetFound)
        {
            SwitchState(killState);
            targetFound = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(searchingForTarget)
        {
            if (other.tag == "Defense")
            {
                searchingForTarget = false;
                targetFound = true;
                searchingHitBox.enabled = false;
                searchingHitBox.isTrigger = false;
                defenseGolemTargets.Add(other.gameObject);
                SwitchState(huntState);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "WeakSpot")
        {
            SwitchState(killShipState);
        }
    }
}
