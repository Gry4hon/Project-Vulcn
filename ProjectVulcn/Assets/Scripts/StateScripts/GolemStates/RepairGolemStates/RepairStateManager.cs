using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class RepairStateManager : MonoBehaviour
{
    RepairStateSetter currentState;

    public GameObject theShip;
    //public Vector3 shipLocation;

    GameObject theGameMaster;
    public GameMaster gameMaster;

    public RepairToShip moveState = new RepairToShip();
    public RepairState repairState = new RepairState();
    public RepairDeath deathState = new RepairDeath();

    public GameObject theRepairGolem;

    public NavMeshAgent repairAgent;

    public Image repairBar;
    public Image healthBar;


    void Start()
    {
        repairAgent = GetComponent<NavMeshAgent>();
        theShip = GameObject.FindGameObjectWithTag("Ship");
        currentState = moveState;

        theGameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        gameMaster = theGameMaster.GetComponent<GameMaster>();
    }


    void Update()
    {
        currentState.RunCurrentState(this);
    }

    public void SwitchState(RepairStateSetter nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ship")
        {
            SwitchState(repairState);
        }
    }

    public void RepairDeath()
    {
        Destroy(theRepairGolem);
    }
}
