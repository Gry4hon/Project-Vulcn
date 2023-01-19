using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairStateManager : MonoBehaviour
{
    public RepairStateSetter currentState;
    public RepairToShip moveState = new RepairToShip();
    public RepairState repairState = new RepairState();
    public RepairDeath deathState = new RepairDeath();

    public GameObject theRepairGolem;

    public Image repairBar;
    public Image healthBar;


    void Start()
    {
        currentState = moveState;
        
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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            SwitchState(repairState);
        }
    }

    public void RepairDeath()
    {
        Destroy(theRepairGolem);
    }


    
}
