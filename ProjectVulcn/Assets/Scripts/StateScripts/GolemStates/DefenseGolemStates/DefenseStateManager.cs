using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class DefenseStateManager : MonoBehaviour
{
   DefenseStateSetter currentState;
   public WanderState wanderState = new WanderState();
   public DefendState defendState = new DefendState();
   public DefenceAttackState attackState = new DefenceAttackState();
   public DefenseDeath defenseDeath = new DefenseDeath();

    [Header("TheGolem")]
    public GameObject defenseGolem;
    public BoxCollider searchingHitBox;
    public NavMeshAgent defenseAgent;

    public float golemHealth = 100f;
    public Image golemHealthBar;
    public bool targetFound = false;
    public bool searchingForTarget = true;

    [Header("Targets")]
    public GameObject movePoint;
    public GameObject scrapWolfTarget;


    void Start()
    {
        defenseAgent = GetComponent<NavMeshAgent>();
        currentState = wanderState;
    }

    void Update()
    {
        currentState.RunCurrentState(this);
    }

    public void SwitchState(DefenseStateSetter nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (targetFound)
        {
            print("Target locked");
            if (collision.collider.tag == "Enemy")
            {
                print("Attacking target");
                targetFound = false;
                SwitchState(attackState);
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (searchingForTarget)
        {
            print("Searching for target");
            if (other.tag == "Enemy")
            {
                targetFound = true;
                searchingForTarget = false;
                scrapWolfTarget = other.gameObject;
                searchingHitBox.enabled = false;
                searchingHitBox.isTrigger = false;
                SwitchState(defendState);

            }
        }

    }





}
