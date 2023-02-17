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
    public bool firstBlood = false;


    [Header("Targets")]
    public GameObject movePoint;
    public List<GameObject> scrapWolfTargets = new List<GameObject>();


    void Start()
    {
        defenseGolem = this.gameObject;
        defenseAgent = GetComponent<NavMeshAgent>();
        currentState = wanderState;
    }

    void Update()
    {
        currentState.RunCurrentState(this);

        if (golemHealth <= 0)
        {
            GameObject.Destroy(defenseGolem);
        }
    }

    public void SwitchState(DefenseStateSetter nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);



    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.gameObject == defendState.theTarget && targetFound)
        {
            SwitchState(attackState);
            targetFound = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (searchingForTarget)
        {
            if (other.tag == "Enemy")
            {
                searchingForTarget = false;
                targetFound= true;
                searchingHitBox.enabled = false;
                searchingHitBox.isTrigger = false;
                scrapWolfTargets.Add(other.gameObject);
                SwitchState(defendState);

            }
        }

        }

    }






